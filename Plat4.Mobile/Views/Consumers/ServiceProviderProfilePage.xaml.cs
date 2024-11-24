using Plat4.Mobile.Models;
using Plat4.Mobile.Services;

namespace Plat4.Mobile.Views.Consumers;

public partial class ServiceProviderProfilePage : ContentPage
{
    private readonly int _serviceProviderId;
    private ServiceProviderProfilePageService _providerService = new();
    private string _providerDocumentCount = string.Empty;
    private string _providerWorkCatalogCount = string.Empty;

    public ServiceProviderProfilePage()
    {
        InitializeComponent();
    }

    public ServiceProviderProfilePage(int serviceProviderId)
    {
        _serviceProviderId = serviceProviderId;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var providerProfile = await _providerService.GetProviderProfile(_serviceProviderId);
        if (providerProfile == null)
        {
            DisplayAlert("View Profile", "Unable to get provider profile", "Cancel");
            Shell.Current.Navigation.PopAsync();
        }

        PopulateProviderFields(providerProfile);
    }

    private void PopulateProviderFields(ServiceProviderProfileModel? providerProfile)
    {
        _providerDocumentCount = GetProviderDocumentCount(providerProfile.id);
        _providerWorkCatalogCount = GetProviderWorkCatalogCount(providerProfile.id);

        Title = string.IsNullOrEmpty(providerProfile.companyName) ? "N/A" : providerProfile.companyName;
        LblBusinessAddress.Text = string.IsNullOrEmpty(providerProfile.location) ? "N/A" : providerProfile.location;
        LblBusinessName.Text = string.IsNullOrEmpty(providerProfile.companyName) ? "N/A" : providerProfile.companyName;
        LblDocumentItemsCount.Text = string.IsNullOrEmpty(providerProfile.address) ? "0" : _providerDocumentCount;
        LblWorkCatalogCount.Text = string.IsNullOrEmpty(providerProfile.address) ? "0" : _providerWorkCatalogCount;

        if (providerProfile.workingHour != null)
        {
            LblStartWorkTime.Text = providerProfile.workingHour.start;
            LblEndWorkTime.Text = providerProfile.workingHour.end;
        }
        else
        {
            LblStartWorkTime.Text = "8:00 AM";
            LblEndWorkTime.Text = "6:00 PM";
        }
    }

    private string GetProviderDocumentCount(int providerProfileId)
    {
        return string.Empty;
    }

    private string GetProviderWorkCatalogCount(int providerProfileId)
    {
        return string.Empty;
    }
}