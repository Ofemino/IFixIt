namespace IFixIt.Mobile.Views.Consumers;

public partial class RequestAJobPage : ContentPage
{
    private readonly int _providerId;
    private RequestAJobPageService _service = new();
    public RequestAJobPage()
    {
        InitializeComponent();
    }

    public RequestAJobPage(int providerId)
    {
        _providerId = providerId;
        InitializeComponent();
    }


}