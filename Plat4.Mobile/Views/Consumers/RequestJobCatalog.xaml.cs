using Plat4.Mobile.Views.Shared;
using ServiceProvider = Plat4.Mobile.Models.ServiceProvider;

namespace Plat4.Mobile.Views.Consumers;

public partial class RequestJobCatalog
{
    private ServiceProvider _provider;

    public RequestJobCatalog()
    {
        InitializeComponent();
    }

    public RequestJobCatalog(ServiceProvider provider)
    {
        _provider= provider;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        lblProviderName.Text = _provider.companyName;
        base.OnAppearing();
    }

    private void RequestJobCatalog_OnBackgroundClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void BtnSendCatalogRequest_OnClicked(object? sender, EventArgs e)
    {
        var catalogChatRequest = new CatalogChatRequest
        {
            ProviderName = lblProviderName.Text,
            SaluteTitle = lblSaluteTitle.Text,
            RequestMessage = lblRequestMessage.Text,
            HasImage = true,
        };
        
        Shell.Current.Navigation.PushAsync(new ChatMessagesPage(_provider.companyName,catalogChatRequest), true);
        // Shell.Current.GoToAsync("///ChatPage");
        MopupService.Instance.PopAsync();
        // Shell.Current.GoToAsync($"{nameof(ChatMessagesPage)}", true, new Dictionary<string, object>
        // {
        //     {"catalogChatRequest", catalogChatRequest}
        // });
    }
}