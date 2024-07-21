using Plat4.Mobile.Views.Shared;

namespace Plat4.Mobile.Views.Consumers;

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

    private async void BtnCustomerSignOut_OnClicked(object? sender, EventArgs e)
    {
        Preferences.Set("token", null);
        // Preferences.Set("email", null);
        Preferences.Set("fullname", null);
        Preferences.Set("userId", null);
        Preferences.Set("userType", null);
        Preferences.Set("phoneNumber", null);

        // await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        Application.Current.MainPage = new LoginPage();

    }
}