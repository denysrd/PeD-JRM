using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeD_JRM.ViewModels;

namespace PeD_JRM.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel
        {
            get;
        }

        public SettingsPage()
        {
            ViewModel = App.GetService<SettingsViewModel>();
            InitializeComponent();
        }

        // Manipulador de evento para o botão de cadastro de Tipo Ingrediente
        private void OnCadastroTipoIngredienteClick(object sender, RoutedEventArgs e)
        {
            // Adicione a lógica desejada aqui
            // Exemplo: Navegar para uma página de cadastro de ingredientes
         //   Frame.Navigate(typeof(CadastroTipoIngredientePage));
        }

        // Manipulador de evento para o botão de cadastro de Tipo Formulação
        private void OnCadastroTipoFormulacaoClick(object sender, RoutedEventArgs e)
        {
            // Adicione a lógica desejada aqui
            // Exemplo: Navegar para uma página de cadastro de formulações
           // Frame.Navigate(typeof(CadastroTipoFormulacaoPage));
        }
    }
}
