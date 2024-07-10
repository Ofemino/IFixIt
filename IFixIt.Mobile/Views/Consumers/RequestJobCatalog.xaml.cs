namespace IFixIt.Mobile.Views.Consumers;

public partial class RequestJobCatalog : ContentPage
{
    private readonly int _providerId;

    public RequestJobCatalog()
    {
        InitializeComponent();
    }

    public RequestJobCatalog(int providerId)
    {
        _providerId = providerId;
        InitializeComponent();
    }
}