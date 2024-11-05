using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using PeD_JRM.Contracts.Services;
using PeD_JRM.ViewModels;
using PeD_JRM.Views;

namespace PeD_JRM.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<HomeViewModel, HomePage>();
        Configure<CadastrosViewModel, CadastrosPage>();
        Configure<ReceitasViewModel, ReceitasPage>();
        Configure<VazioViewModel, VazioPage>();
        Configure<ListarDetalhesViewModel, ListarDetalhesPage>();
        Configure<GradeDeConteúdoViewModel, GradeDeConteúdoPage>();
        Configure<GradeDeConteúdoDetailViewModel, GradeDeConteúdoDetailPage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<GradeDeDadosViewModel, GradeDeDadosPage>();
        Configure<FornecedorViewModel, FornecedorPage>();
        Configure<TipoIngredienteViewModel, TipoIngredientePage>();
        Configure<TipoFormulacaoViewModel, TipoFormulacaoPage>();
        Configure<InsumosViewModel, InsumosPage>();
        Configure<FlavorizantesViewModel, FlavorizantesPage>();
        Configure<ComponentesAromaticosViewModel, ComponentesAromaticosPage>();
        Configure<EmbalagensViewModel, EmbalagensPage>();
        Configure<FormulacaoEssenciaViewModel, FormulacaoEssenciaPage>();
        Configure<FormulacaoAromaViewModel, FormulacaoAromaPage>();

    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
