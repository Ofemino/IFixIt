using System.ComponentModel;

namespace Plat4.Mobile.ViewModels;

[QueryProperty(nameof(ProviderName), "providerName")]
public partial class ChatMessagesPageViewModel : ObservableObject
{
    [ObservableProperty] string providerName;
    private ObservableCollection<object> messages { get; set; } = new();
    [ObservableProperty] Author currentUser;
    [ObservableProperty] string title;


    public ChatMessagesPageViewModel()
    {
        // messages = new ObservableCollection<object>();
        currentUser = new Author { Name = "Nancy" };
        GenerateMessages();
    }

    public ObservableCollection<object> Messages
    {
        get { return messages; }
        set { messages = value; }
    }
    //
    // public Author CurrentUser
    // {
    //     get { return currentUser; }
    //     set
    //     {
    //         currentUser = value;
    //         RaisePropertyChanged("CurrentUser");
    //     }
    // }

    // public void RaisePropertyChanged(string propName)
    // {
    //     if (PropertyChanged != null)
    //     {
    //         PropertyChanged(this, new PropertyChangedEventArgs(propName));
    //     }
    // }

    private void GenerateMessages()
    {
        var msg = ProviderName;
        messages.Add(new TextMessage()
        {
            Author = currentUser,
            Text =
                "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",
            DateTime = DateTime.Now.AddDays(-2)
        });

        messages.Add(new TextMessage()
        {
            Author = new Author() { Avatar = "default_avatar.png" },
            Text = "Oh! That's great.",
            DateTime = DateTime.Now.AddDays(-2).AddMinutes(30)
        });

        messages.Add(new TextMessage()
        {
            Author = new Author() { Avatar = "default_avatar.png" },
            Text = "That is good news.",
            DateTime = DateTime.Now.AddDays(-1).AddMinutes(40)
        });

        messages.Add(new TextMessage()
        {
            Author = new Author() { Avatar = "default_avatar.png" },
            Text = "Are we going to develop the app natively or hybrid?",
            DateTime = DateTime.Now.AddDays(-1).AddMinutes(20)
        });

        messages.Add(new TextMessage()
        {
            Author = currentUser,
            Text = "We should develop this app in .NET MAUI, since it provides native experience and performance.\",",
            DateTime = DateTime.Now
        });
    }
}