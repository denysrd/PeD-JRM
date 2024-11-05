using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeD_JRM.ViewModels;
using Microsoft.UI.Xaml.Input;
using PeD_JRM.Contracts.Services;
using System.Diagnostics;

namespace PeD_JRM.Views;

public sealed partial class CadastrosPage : Page
{
    public CadastrosViewModel ViewModel
    {
        get;
    }

    private readonly INavigationService _navigationService;

    public CadastrosPage()
    {
        ViewModel = App.GetService<CadastrosViewModel>();
        InitializeComponent();
        // Usando o Service Locator para obter o INavigationService
        _navigationService = App.GetService<INavigationService>();
    }
    private void OnFornecedorTapped(object sender, TappedRoutedEventArgs e) =>
           NavigateToPage(typeof(FornecedorViewModel).FullName);

    private void OnTipoIngredienteTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(TipoIngredienteViewModel).FullName);

    private void OnTipoFormulacaoTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(TipoFormulacaoViewModel).FullName);

    private void OnInsumosTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(InsumosViewModel).FullName);

    private void OnFlavorizantesTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(FlavorizantesViewModel).FullName);

    private void OnComponentesAromaticosTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(ComponentesAromaticosViewModel).FullName);

    private void OnEmbalagensTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(EmbalagensViewModel).FullName);

    private void OnFormulacaoEssenciaTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(FormulacaoEssenciaViewModel).FullName);

    private void OnFormulacaoAromaTapped(object sender, TappedRoutedEventArgs e) =>
        NavigateToPage(typeof(FormulacaoAromaViewModel).FullName);

    // Método auxiliar para navegação
    private void NavigateToPage(string pageKey)
    {
        if (_navigationService == null)
        {
            Debug.WriteLine("Erro: _navigationService está nulo.");
            return;
        }

        bool navigated = _navigationService.NavigateTo(pageKey);

        if (!navigated)
        {
            Debug.WriteLine($"Erro: Não foi possível navegar para a página com chave {pageKey}.");
        }
    }

}
