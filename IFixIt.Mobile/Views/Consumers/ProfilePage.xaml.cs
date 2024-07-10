namespace IFixIt.Mobile.Views.Consumers;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblAccountEmail.Text = Preferences.Get("email", "");
        lblAccountName.Text = Preferences.Get("fullname", "");
        lblAccountPhone.Text = Preferences.Get("phoneNumber", "");
    }
}