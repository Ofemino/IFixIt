namespace Plat4.Mobile.Views.Consumers;

public partial class RequestJobCatalog
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

    private void RequestJobCatalog_OnBackgroundClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}