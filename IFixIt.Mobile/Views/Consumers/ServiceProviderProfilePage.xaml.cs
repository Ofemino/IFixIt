namespace IFixIt.Mobile.Views.Consumers;

public partial class ServiceProviderProfilePage : ContentPage
{
    private readonly int _serviceProviderId;
    private ServiceProviderProfilePageService _providerService = new();
    private string _providerDocumentCount = string.Empty;
    private string _providerWorkCatalogCount = string.Empty;
    private string _providerWorkStart = string.Empty;
    private string _providerWorkEnds = string.Empty;

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


        lblBusinessAddress.Text = string.IsNullOrEmpty(providerProfile.address) ? "N/A" : providerProfile.address;
        lblBusinessName.Text = string.IsNullOrEmpty(providerProfile.companyName) ? "N/A" : providerProfile.companyName;
        lblDocumentItemsCount.Text = string.IsNullOrEmpty(providerProfile.address) ? "0" : _providerDocumentCount;
        lblWorkCatalogCount.Text = string.IsNullOrEmpty(providerProfile.address) ? "0" : _providerWorkCatalogCount;

        if (providerProfile.workingHour != null)
        {
            lblStartWorkTime.Text = providerProfile.workingHour.start;
            lblEndWorkTime.Text = providerProfile.workingHour.end;
        }
        else
        {
            lblStartWorkTime.Text =  "8:00 AM";
            lblEndWorkTime.Text =  "6:00 PM";
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