namespace IFixIt.Mobile.Views.Shared;

public partial class ChatMessagesPage : ContentPage
{
    private readonly string _providerName;
    private ChatMessagesPageViewModel chatMessagesVM = new();

    public ChatMessagesPage()
    {
        InitializeComponent();
        BindingContext = chatMessagesVM;
        Title = _providerName;
    }

    public ChatMessagesPage(string providerName)
    {
        _providerName = providerName;
        InitializeComponent();
        BindingContext = chatMessagesVM;
        Title = _providerName;
    }
}