using Microsoft.UI.Xaml.Controls;

using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

public sealed partial class ReceitasPage : Page
{
    public ReceitasViewModel ViewModel
    {
        get;
    }

    public ReceitasPage()
    {
        ViewModel = App.GetService<ReceitasViewModel>();
        InitializeComponent();
    }
}
