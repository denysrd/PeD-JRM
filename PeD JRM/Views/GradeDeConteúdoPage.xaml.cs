using Microsoft.UI.Xaml.Controls;

using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

public sealed partial class GradeDeConteúdoPage : Page
{
    public GradeDeConteúdoViewModel ViewModel
    {
        get;
    }

    public GradeDeConteúdoPage()
    {
        ViewModel = App.GetService<GradeDeConteúdoViewModel>();
        InitializeComponent();
    }
}
