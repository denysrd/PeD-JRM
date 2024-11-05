using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

public sealed partial class ListarDetalhesPage : Page
{
    public ListarDetalhesViewModel ViewModel
    {
        get;
    }

    public ListarDetalhesPage()
    {
        ViewModel = App.GetService<ListarDetalhesViewModel>();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
