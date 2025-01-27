using Microsoft.Maui.Storage;
using Plat4.Mobile.ViewModels;
using Syncfusion.Maui.Chat.Internals;
using ServiceProvider = Plat4.Mobile.Models.ServiceProvider;

namespace Plat4.Mobile.Views.Shared;

public partial class ChatMessagesPage : ContentPage
{
    private readonly string _providerName;
    private readonly CatalogChatRequest _catalogChatRequest;
    private ChatMessagesPageViewModel chatMessagesVM = new();
    private string userEmail = string.Empty;
    private ServiceProvider _serviceProvider;

    public ChatMessagesPage()
    {
        InitializeComponent();
        BindingContext = chatMessagesVM;
        Title = _providerName;

        userEmail = Preferences.Get("email", "");
    }

    public ChatMessagesPage(string providerName)
    {
        _providerName = providerName;
        InitializeComponent();
        BindingContext = chatMessagesVM;
        Title = _providerName;
    }


    public ChatMessagesPage(string providerName, CatalogChatRequest catalogChatRequest)
    {
        InitializeComponent();
        BindingContext = chatMessagesVM;
        _providerName = providerName;
        _catalogChatRequest = catalogChatRequest;
        Title = _providerName;
    }

    protected override void OnAppearing()
    {
        SfChat.Messages.Add(new ImageMessage()
        {
            Source = _catalogChatRequest.HasImage ? "CatalogRequest.jpg" : string.Empty,
            Author = new Author() { Name = userEmail, Avatar = "People_Circle23.png" },
            Text = _catalogChatRequest.SaluteTitle + Environment.NewLine + _catalogChatRequest.ProviderName +
                   Environment.NewLine + _catalogChatRequest.RequestMessage,
        });
        base.OnAppearing();
    }

    private void sfChat_AttachmentButtonClicked(object sender, EventArgs e)
    {
        SfChat.Messages.Add(new ImageMessage()
        {
            Source = "Catalog.jpg",
            Author = new Author() { Name = userEmail, Avatar = "People_Circle23.png" },
            Text = "Catalog Request Sent",
        });
    }

    private void sfChat_ImageTapped(object sender, ImageTappedEventArgs e)
    {
        //if (e.Message.Author.Name != userEmail)
        //{

        //}
    }

    private void sfChat_MessageLongPressed(object sender, MessageLongPressedEventArgs e)
    {
        if (e.Message != null)
        {
        }
    }
}