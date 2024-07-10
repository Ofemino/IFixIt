using System.ComponentModel;
using IFixIt.Mobile.Views.Consumers;
using IFixIt.Mobile.Views.Shared;

namespace IFixIt.Mobile.ViewModels;

public partial class ChatPageViewModel : ObservableObject //INotifyPropertyChanged
{
    /// <summary>
    /// Collection of messages in a conversation.
    /// </summary>
    public ObservableCollection<TextMessage> Chats { get; set; }

    [ObservableProperty] TextMessage selectedMessage;

    /// <summary>
    /// Current user of chat.
    /// </summary>
    [ObservableProperty] Author currentUser;

    public ChatPageViewModel()
    {
        Chats = new ObservableCollection<TextMessage>();
        currentUser = new Author { Name = "Nancy" };
        LoadChats();
    }

    private void LoadChats()
    {
        Chats.Add(new TextMessage()
        {
            Author = new Author() { Name = "Andrea", Avatar = "default_avatar.png" },
            Text = "Oh! That's great.",
            DateTime = DateTime.Now.AddDays(-2).AddMinutes(30)
        });

        Chats.Add(new TextMessage()
        {
            Author = new Author() { Name = "Harrison", Avatar = "default_avatar.png" },
            Text = "That is good news.",
            DateTime = DateTime.Now.AddDays(-1).AddMinutes(40)
        });

        Chats.Add(new TextMessage()
        {
            Author = new Author() { Name = "Margaret", Avatar = "default_avatar.png" },
            Text = "Are we going to develop the app natively or hybrid?",
            DateTime = DateTime.Now.AddDays(-1).AddMinutes(20)
        });
    }


    // public ObservableCollection<TextMessage> Chats
    // {
    //     get { return chats; }
    //
    //     set { chats = value; }
    // }

    /// <summary>
    /// Gets or sets the current user of the message.
    /// </summary>
    // public Author CurrentUser
    // {
    //     get { return currentUser; }
    //     set
    //     {
    //         currentUser = value;
    //         RaisePropertyChanged("CurrentUser");
    //     }
    // }
    //
    // public TextMessage SelectedMessage
    // {
    //     get { return selectedMessage; }
    //     set
    //     {
    //         selectedMessage = value;
    //         RaisePropertyChanged("SelectedMessage");
    //     }
    // }

    /// <summary>
    /// Property changed handler.
    /// </summary>
    // public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Occurs when property is changed.
    /// </summary>
    /// <param name="propName">changed property name</param>
    // public void RaisePropertyChanged(string propName)
    // {
    //     if (PropertyChanged != null)
    //     {
    //         PropertyChanged(this, new PropertyChangedEventArgs(propName));
    //     }
    // }
    [RelayCommand]
    public void SelectionChangedControl()
    {
        Console.WriteLine(SelectedMessage);
        if (SelectedMessage == null) return;
        string providerName = SelectedMessage.Author.Name;
        Shell.Current.Navigation.PushAsync(new ChatMessagesPage(providerName), true);
        SelectedMessage = null;
    }
}