using Plat4.Mobile.Models;
using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Consumers;

namespace Plat4.Mobile.ViewModels;

[QueryProperty(nameof(ServiceProvidedModel), "selectedProvider")]
public partial class ProviderServicePageViewModel : ObservableObject
{
    public ObservableCollection<ServiceProviderFeedbacks> ServiceProviderFeedbackList = new();
    private SelectedServiceOptionsPageService _serviceOptionsPageService = new();
    [ObservableProperty] ServiceProvidedModel _selectedServiceProvidedModel;
    [ObservableProperty] string pageTitle;

    public ProviderServicePageViewModel()
    {
        GetSelectedServiceProviderDetails();
        GetServiceProviderFeedbacks();
    }

    private async Task GetServiceProviderFeedbacks()
    {
        // var feedbacks =
        //     await _serviceOptionsPageService.GetServiceProviderFeedbacks(SelectedServiceProvidedModel.Id);
        // if (feedbacks.Count > 0)
        // {
        //     foreach (var feedback in feedbacks)
        //     {
        //         ServiceProviderFeedbackList.Add(feedback);
        //     }
        //
        //     // SelectedServiceProvidedModel.PageTitle = SelectedServiceProvidedModel.Name;
        //     // SelectedServiceProvidedModel.ServiceProviderFeedbackList = ServiceProviderFeedbackList.ToList();
        // }
    }

    private async Task GetSelectedServiceProviderDetails()
    {
        if (SelectedServiceProvidedModel != null)
        {
            // SelectedServiceProvidedModel =
            //     await _serviceOptionsPageService.GetSelectedServiceOptionById(SelectedServiceProvidedModel.Id);
            // PageTitle = SelectedServiceProvidedModel.Name;
        }
    }

    [RelayCommand]
    void ViewProfileClicked()
    {
        Shell.Current.Navigation.PushAsync(new ServiceProviderProfilePage(), true);
    }

    [RelayCommand]
    void RequestJobClicked()
    {
        Shell.Current.Navigation.PushAsync(new RequestAJobPage(), true);
    }

    [RelayCommand]
    void RequestJonCatalogClicked()
    {
        Shell.Current.Navigation.PushAsync(new RequestJobCatalog(), true);
    }
}