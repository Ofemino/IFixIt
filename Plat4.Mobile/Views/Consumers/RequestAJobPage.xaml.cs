using System.Collections;
using Plat4.Mobile.Models;
using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Shared;
using ServiceProvider = Plat4.Mobile.Models.ServiceProvider;

namespace Plat4.Mobile.Views.Consumers;

public partial class RequestAJobPage
{
    private readonly ServiceProvider _provider;
    private RequestAJobPageService _service = new();
    public RequestAJobPageQuestions SelectedQuestion { get; set; }

    public List<RequestAJobPageQuestions> QuestionBanksList { get; set; } = new()
    {
        new RequestAJobPageQuestions { Question = "Hi, I want you to do a job for me." },
        new RequestAJobPageQuestions { Question = "Hello, I have a job for you." },
        new RequestAJobPageQuestions { Question = "Are you available to fix my challenge." },
    };

    public RequestAJobPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public RequestAJobPage(ServiceProvider provider)
    {
        _provider = provider;
        InitializeComponent();
        BindingContext = this;
    }


    private void RequestAJobPage_OnBackgroundClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void BtnStartAChatMessage_OnClicked(object? sender, EventArgs e)
    {
        var startChatRequest = new CatalogChatRequest();
        if (SelectedQuestion != null)
        {
            startChatRequest.ProviderName = _provider.companyName;
            startChatRequest.RequestMessage = SelectedQuestion.Question;
            startChatRequest.HasImage = false;
        }

        Shell.Current.Navigation.PushAsync(new ChatMessagesPage(_provider.companyName, startChatRequest), true);
        // Shell.Current.GoToAsync("///ChatPage");
        MopupService.Instance.PopAsync();
        // Shell.Current.GoToAsync($"{nameof(ChatMessagesPage)}", true, new Dictionary<string, object>
        // {
        //     {"catalogChatRequest", catalogChatRequest}
        // });
    }
}