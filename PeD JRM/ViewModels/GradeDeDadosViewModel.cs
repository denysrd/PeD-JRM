using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using PeD_JRM.Contracts.ViewModels;
using PeD_JRM.Core.Contracts.Services;
using PeD_JRM.Core.Models;

namespace PeD_JRM.ViewModels;

public partial class GradeDeDadosViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public GradeDeDadosViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
