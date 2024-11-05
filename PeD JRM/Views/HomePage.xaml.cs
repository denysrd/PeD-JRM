using Microsoft.UI.Xaml.Controls;

using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
    }
    private void NavigateToPage(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        if (sender is NavigationViewItem item && item.Tag is string pageName)
        {
            Type pageType = Type.GetType($"PeD_JRM.Views.{pageName}");

            if (pageType != null)
            {
                Frame.Navigate(pageType);
            }
        }
    }
}
