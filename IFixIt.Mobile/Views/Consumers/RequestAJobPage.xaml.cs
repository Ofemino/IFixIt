using System.Collections;

namespace IFixIt.Mobile.Views.Consumers;

public partial class RequestAJobPage
{
    private readonly int _providerId;
    private RequestAJobPageService _service = new();

    public List<RequestAJobPageQuestions> QuestionBanksList { get; set; } = new List<RequestAJobPageQuestions>
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

    public RequestAJobPage(int providerId)
    {
        _providerId = providerId;
        InitializeComponent();
        BindingContext = this;
    }


    private void RequestAJobPage_OnBackgroundClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}