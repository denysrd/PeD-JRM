using Microsoft.UI.Xaml.Controls;

using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

public sealed partial class VazioPage : Page
{
    public VazioViewModel ViewModel
    {
        get;
    }

    public VazioPage()
    {
        ViewModel = App.GetService<VazioViewModel>();
        InitializeComponent();
    }
}
