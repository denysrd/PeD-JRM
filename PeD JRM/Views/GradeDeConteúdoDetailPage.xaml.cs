using CommunityToolkit.WinUI.UI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using PeD_JRM.Contracts.Services;
using PeD_JRM.ViewModels;

namespace PeD_JRM.Views;

public sealed partial class GradeDeConteúdoDetailPage : Page
{
    public GradeDeConteúdoDetailViewModel ViewModel
    {
        get;
    }

    public GradeDeConteúdoDetailPage()
    {
        ViewModel = App.GetService<GradeDeConteúdoDetailViewModel>();
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();

            if (ViewModel.Item != null)
            {
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
