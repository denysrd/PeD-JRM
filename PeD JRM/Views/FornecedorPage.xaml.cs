using System.Text.RegularExpressions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PeD_JRM.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class FornecedorPage : Page
{
    private const int MaxDocumentoLength = 18;

    public FornecedorPage()
    {
        this.InitializeComponent();
    }

    private void OnDocumentoTextChanged(object sender, TextChangedEventArgs e)
    {
        // Pega a posição original do cursor antes de formatar
        int originalCursorPosition = DocumentoTextBox.SelectionStart;

        string documento = DocumentoTextBox.Text;

        // Remove qualquer caractere não numérico
        documento = Regex.Replace(documento, "[^0-9]", "");

        // Limita o número de dígitos a 15
        if (documento.Length > 15)
        {
            documento = documento.Substring(0, 15);
        }

        // Formata o texto conforme o número de dígitos
        if (documento.Length <= 11)
        {
            // Formatação para CPF: 000.000.000-00
            if (documento.Length > 3)
                documento = documento.Insert(3, ".");
            if (documento.Length > 7)
                documento = documento.Insert(7, ".");
            if (documento.Length > 11)
                documento = documento.Insert(11, "-");
        }
        else
        {
            // Formatação para CNPJ: 00.000.000/0000-00
            if (documento.Length > 2)
                documento = documento.Insert(2, ".");
            if (documento.Length > 6)
                documento = documento.Insert(6, ".");
            if (documento.Length > 10)
                documento = documento.Insert(10, "/");
            if (documento.Length > 15)
                documento = documento.Insert(15, "-");
        }

        // Limita o texto formatado a 19 caracteres
        if (documento.Length > MaxDocumentoLength)
        {
            documento = documento.Substring(0, MaxDocumentoLength);
        }

        // Define o novo texto do TextBox
        DocumentoTextBox.Text = documento;

        // Calcula a nova posição do cursor considerando as formatações adicionadas
        int formattedCursorPosition = originalCursorPosition;

        // Ajuste do cursor para CPF (11 dígitos)
        if (formattedCursorPosition > 3) formattedCursorPosition++;
        if (formattedCursorPosition > 7) formattedCursorPosition++;
        if (formattedCursorPosition > 11) formattedCursorPosition++;

        // Ajuste do cursor para CNPJ (14 dígitos)
        if (documento.Length > 14) // Quando há formatação para CNPJ
        {
            if (formattedCursorPosition > 2) formattedCursorPosition++;
            if (formattedCursorPosition > 6) formattedCursorPosition++;
            if (formattedCursorPosition > 10) formattedCursorPosition++;
            if (formattedCursorPosition > 15) formattedCursorPosition++;
        }

        // Define a posição do cursor, garantindo que ele não ultrapasse o comprimento do texto
        DocumentoTextBox.SelectionStart = Math.Min(formattedCursorPosition, documento.Length);
    }

    private void OnCadastrarButtonClick(object sender, RoutedEventArgs e)
    {
        string documento = DocumentoTextBox.Text;
        string nome = NomeTextBox.Text;
        string email = EmailTextBox.Text;
        string telefone = TelefoneTextBox.Text;

        if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefone))
        {
            var dialog = new ContentDialog
            {
                Title = "Erro",
                Content = "Todos os campos são obrigatórios.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };
            _ = dialog.ShowAsync();
            return;
        }

        var successDialog = new ContentDialog
        {
            Title = "Sucesso",
            Content = "Fornecedor cadastrado com sucesso!",
            CloseButtonText = "OK",
            XamlRoot = this.XamlRoot
        };
        _ = successDialog.ShowAsync();

        DocumentoTextBox.Text = string.Empty;
        NomeTextBox.Text = string.Empty;
        EmailTextBox.Text = string.Empty;
        TelefoneTextBox.Text = string.Empty;
    }
}
