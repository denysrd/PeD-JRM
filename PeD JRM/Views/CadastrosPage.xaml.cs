using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeD_JRM.ViewModels;
using Microsoft.UI.Xaml.Input;

namespace PeD_JRM.Views;

public sealed partial class CadastrosPage : Page
{
    public CadastrosViewModel ViewModel
    {
        get;
    }

    public CadastrosPage()
    {
        ViewModel = App.GetService<CadastrosViewModel>();
        InitializeComponent();
    }
    private void OnFornecedorTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(FornecedorPage));
    }

    private void OnTipoIngredienteTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(TipoIngredientePage));
    }

    private void OnTipoFormulacaoTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(TipoFormulacaoPage));
    }

    private void OnInsumosTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(InsumosPage));
    }

    private void OnFlavorizantesTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(FlavorizantesPage));
    }

    private void OnComponentesAromaticosTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(ComponentesAromaticosPage));
    }

    private void OnEmbalagensTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(EmbalagensPage));
    }

    private void OnFormulacaoEssenciaTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(FormulacaoEssenciaPage));
    }

    private void OnFormulacaoAromaTapped(object sender, TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(FormulacaoAromaPage));
    }

}
