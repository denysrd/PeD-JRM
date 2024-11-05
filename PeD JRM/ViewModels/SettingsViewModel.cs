using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using PeD_JRM.Contracts.Services;
using PeD_JRM.Data;
using PeD_JRM.Models;

namespace PeD_JRM.ViewModels
{
    public partial class SettingsViewModel : ObservableRecipient
    {
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly AppDbContext _dbContext;

        [ObservableProperty]
        private ElementTheme _elementTheme;

        [ObservableProperty]
        private string _versionDescription;

        // Coleções para armazenar os dados
        [ObservableProperty]
        private ObservableCollection<TipoIngrediente> tipoIngredientes;

        [ObservableProperty]
        private ObservableCollection<TipoFormulacao> tipoFormulacoes;

        public ICommand SwitchThemeCommand
        {
            get;
        }

        public SettingsViewModel(IThemeSelectorService themeSelectorService, AppDbContext dbContext)
        {
            _themeSelectorService = themeSelectorService;
            _dbContext = dbContext;
            _elementTheme = _themeSelectorService.Theme;
            _versionDescription = GetVersionDescription();

            SwitchThemeCommand = new RelayCommand<ElementTheme>(
                async (param) =>
                {
                    if (ElementTheme != param)
                    {
                        ElementTheme = param;
                        await _themeSelectorService.SetThemeAsync(param);
                    }
                });

            TipoIngredientes = new ObservableCollection<TipoIngrediente>();
            TipoFormulacoes = new ObservableCollection<TipoFormulacao>();

            // Carrega os dados do banco de dados
            CarregarDados();
        }

        private void CarregarDados()
        {
            // Consulta os dados do banco de dados e adiciona às coleções
            var ingredientes = _dbContext.TipoIngredientes.ToList();
            foreach (var ingrediente in ingredientes)
            {
                TipoIngredientes.Add(ingrediente);
            }

            var formulacoes = _dbContext.TipoFormulacoes.ToList();
            foreach (var formulacao in formulacoes)
            {
                TipoFormulacoes.Add(formulacao);
            }
        }

        private static string GetVersionDescription()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return $"{"AppDisplayName"} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
