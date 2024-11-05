using Microsoft.UI.Xaml.Controls;

using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class GradeDeDadosPage : Page
{
    public GradeDeDadosViewModel ViewModel
    {
        get;
    }

    public GradeDeDadosPage()
    {
        ViewModel = App.GetService<GradeDeDadosViewModel>();
        InitializeComponent();
    }
}
