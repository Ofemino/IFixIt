using Plat4.Mobile.Models;
using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Consumers;

namespace Plat4.Mobile.ViewModels;

[QueryProperty(nameof(SelectedServiceOptions), "serviceOptions")]
public partial class SelectedServiceOptionsViewModel : ObservableObject
{
    private SelectedServiceOptionsPageService _serviceOptions = new();

    [ObservableProperty] SelectedServiceOptions selectedServiceOptions;
    [ObservableProperty] ServiceProvidedModel _selectedServiceProvided;
    public ObservableCollection<ServiceProvidedModel> ServiceProvidersList { get; set; } = new();

    public SelectedServiceOptionsViewModel()
    {
        GetSelectedServiceOption();
    }

    private async void GetSelectedServiceOption()
    {
        ServiceProvidersList.Clear();
        var response = await _serviceOptions.GetSelectedServiceOption(selectedServiceOptions);
        if (response is { Count: > 0 })
        {
            // foreach (ServiceProvidedModel providers in response)
            // {
            //     ServiceProvidersList.Add(providers);
            // }
        }
    }

    [RelayCommand]
    void LoadSubServiceProvider()
    {
        if (SelectedServiceProvided == null) return;
        // Shell.Current.Navigation.PushAsync(new ProviderServicePage(SelectedServiceProvided), true);
        Shell.Current.GoToAsync($"{nameof(ProviderServicePage)}", true, new Dictionary<string, object>
        {
            {"selectedProvider", SelectedServiceProvided}
        });

        SelectedServiceProvided = null;
    }
}