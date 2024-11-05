using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using PeD_JRM.Data;
using PeD_JRM.Models;
using System.Linq;

namespace PeD_JRM.Views
{
    public sealed partial class FornecedorPage : Page
    {
        private const int MaxDocumentoLength = 18;
        private readonly AppDbContext _context;

        public ObservableCollection<FornecedorModel> Fornecedores { get; set; } = new ObservableCollection<FornecedorModel>();

        private FornecedorModel? _fornecedorEmEdicao;

        public FornecedorPage()
        {
            InitializeComponent();
            _context = App.GetService<AppDbContext>();
            LoadFornecedores();
        }

        private async void LoadFornecedores()
        {
            var fornecedores = await _context.Fornecedor.ToListAsync();
            Fornecedores.Clear();
            foreach (var fornecedor in fornecedores)
            {
                Fornecedores.Add(fornecedor);
            }
            FornecedoresListView.ItemsSource = Fornecedores;
        }

        public async void OnCadastrarButtonClick(object sender, RoutedEventArgs e)
        {
            if (_fornecedorEmEdicao == null)
            {
                var novoFornecedor = new FornecedorModel
                {
                    Documento = DocumentoTextBox.Text,
                    Nome = NomeTextBox.Text,
                    Email = EmailTextBox.Text,
                    Telefone = TelefoneTextBox.Text
                };

                _context.Fornecedor.Add(novoFornecedor);
                await _context.SaveChangesAsync();
                Fornecedores.Add(novoFornecedor);

                var dialog = new ContentDialog
                {
                    Title = "Sucesso",
                    Content = "Fornecedor cadastrado com sucesso!",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();
            }
            else
            {
                _fornecedorEmEdicao.Documento = DocumentoTextBox.Text;
                _fornecedorEmEdicao.Nome = NomeTextBox.Text;
                _fornecedorEmEdicao.Email = EmailTextBox.Text;
                _fornecedorEmEdicao.Telefone = TelefoneTextBox.Text;

                _context.Fornecedor.Update(_fornecedorEmEdicao);
                await _context.SaveChangesAsync();
                LoadFornecedores();

                var dialog = new ContentDialog
                {
                    Title = "Sucesso",
                    Content = "Fornecedor atualizado com sucesso!",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();

                _fornecedorEmEdicao = null;
                CadastrarButton.Content = "Cadastrar";
                CancelarButton.Visibility = Visibility.Collapsed;
            }

            LimparCampos();
        }

        private async void OnExcluirButtonClick(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).Tag;
            var fornecedor = await _context.Fornecedor.FindAsync(id);

            if (fornecedor != null)
            {
                var confirmDialog = new ContentDialog
                {
                    Title = "Confirmação",
                    Content = "Tem certeza que deseja excluir este fornecedor?",
                    PrimaryButtonText = "Sim",
                    CloseButtonText = "Não",
                    XamlRoot = this.XamlRoot
                };

                var result = await confirmDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    _context.Fornecedor.Remove(fornecedor);
                    await _context.SaveChangesAsync();
                    Fornecedores.Remove(fornecedor);
                }
            }
        }

        private void OnEditarButtonClick(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).Tag;
            var fornecedor = Fornecedores.FirstOrDefault(f => f.Id_Fornecedor == id);

            if (fornecedor != null)
            {
                DocumentoTextBox.Text = fornecedor.Documento;
                NomeTextBox.Text = fornecedor.Nome;
                EmailTextBox.Text = fornecedor.Email;
                TelefoneTextBox.Text = fornecedor.Telefone;

                _fornecedorEmEdicao = fornecedor;
                CadastrarButton.Content = "Salvar";
                CancelarButton.Visibility = Visibility.Visible;
            }
        }

        private void OnCancelarButtonClick(object sender, RoutedEventArgs e)
        {
            _fornecedorEmEdicao = null;
            LimparCampos();
            CadastrarButton.Content = "Cadastrar";
            CancelarButton.Visibility = Visibility.Collapsed;
        }

        private void LimparCampos()
        {
            DocumentoTextBox.Text = string.Empty;
            NomeTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TelefoneTextBox.Text = string.Empty;
        }

        private void FornecedoresListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is FornecedorModel fornecedor)
            {
                DocumentoTextBox.Text = fornecedor.Documento;
                NomeTextBox.Text = fornecedor.Nome;
                EmailTextBox.Text = fornecedor.Email;
                TelefoneTextBox.Text = fornecedor.Telefone;

                _fornecedorEmEdicao = fornecedor;
                CadastrarButton.Content = "Salvar";
                CancelarButton.Visibility = Visibility.Visible;
            }
        }
        void OnDocumentoTextChanged(object sender, TextChangedEventArgs e)
        {
            // Salva a posição inicial do cursor
            int cursorPosition = DocumentoTextBox.SelectionStart;

            // Remove todos os caracteres não numéricos
            string documento = Regex.Replace(DocumentoTextBox.Text, "[^0-9]", "");

            // Limita o comprimento máximo do documento
            if (documento.Length > MaxDocumentoLength)
            {
                documento = documento.Substring(0, MaxDocumentoLength);
            }

            // Formata o CPF ou CNPJ
            string formattedDocumento = documento;
            if (documento.Length <= 11) // CPF
            {
                if (documento.Length > 3) formattedDocumento = formattedDocumento.Insert(3, ".");
                if (documento.Length > 6) formattedDocumento = formattedDocumento.Insert(7, ".");
                if (documento.Length > 9) formattedDocumento = formattedDocumento.Insert(11, "-");
            }
            else // CNPJ
            {
                if (documento.Length > 2) formattedDocumento = formattedDocumento.Insert(2, ".");
                if (documento.Length > 5) formattedDocumento = formattedDocumento.Insert(6, ".");
                if (documento.Length > 8) formattedDocumento = formattedDocumento.Insert(10, "/");
                if (documento.Length > 12) formattedDocumento = formattedDocumento.Insert(15, "-");
            }

            // Atualiza o texto da caixa de texto e ajusta a posição do cursor
            DocumentoTextBox.Text = formattedDocumento;

            // Ajusta a posição do cursor após a formatação
            int newCursorPosition = cursorPosition;

            // Calcula o deslocamento do cursor devido aos caracteres de formatação inseridos
            if (cursorPosition > 3 && documento.Length > 3) newCursorPosition++;
            if (cursorPosition > 6 && documento.Length > 6) newCursorPosition++;
            if (cursorPosition > 9 && documento.Length > 9) newCursorPosition++;
            if (documento.Length > 11 && cursorPosition > 11) newCursorPosition++;
            if (documento.Length > 14 && cursorPosition > 14) newCursorPosition++;

            DocumentoTextBox.SelectionStart = newCursorPosition;
        }

    }
}
