namespace IFixIt.Mobile.Views.Consumers;

public partial class ServiceProviderProfilePage : ContentPage
{
    private readonly int _serviceProviderId;
    private ServiceProviderProfilePageService _serviceProvider = new();

    public ServiceProviderProfilePage()
    {
        InitializeComponent();
    }

    public ServiceProviderProfilePage(int serviceProviderId)
    {
        _serviceProviderId = serviceProviderId;
        InitializeComponent();
    }
}