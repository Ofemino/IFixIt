using Plat4.Mobile.DataTransferObjects;
using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Consumers;
using Plat4.Mobile.Views.Providers;
using SelectionChangedEventArgs = Syncfusion.Maui.Buttons.SelectionChangedEventArgs;

namespace Plat4.Mobile.Views.Shared;

public partial class LoginPage : ContentPage
{
    public int SegmentButtonSelectedIndex { get; set; } = 0;
    private LoginServices _loginServices = new();

    public LoginPage()
    {
        InitializeComponent();
    }

    private void BtnProviderType_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        SegmentButtonSelectedIndex = (int)e.NewIndex;
        // DisplayAlert("Selected", $"item : {SegmentButtonSelectedIndex}", "Ok");
    }

    private void BtnLogin_OnClicked(object? sender, EventArgs e)
    {
        if (SegmentButtonSelectedIndex == 1)
            DoLogin("PROVIDER");
        else
            DoLogin("CONSUMER");
    }


    private async void DoLogin(string userType)
    {
        bool isValid = DoValidation();
        if (!isValid)
            DisplayAlert("Login Details", "Please check user email or password!", "Ok");

        var appUser = new UserLogin
        {
            email = TxtEmail.Text, password = TxtPassword.Text,
            userType = userType
        };
        var response = await _loginServices.DoLogin(appUser);
        if (response > 0)
        {
            if (userType == "CONSUMER")
                App.Current.MainPage = new HomePage();
            else
                App.Current.MainPage = new ProviderHomePage();
        }
        else
        {
            DisplayAlert("Alert!", "Something went wrong, check your login details.", "Ok");
        }
    }

    private bool DoValidation()
    {
        if (string.IsNullOrWhiteSpace(TxtEmail.Text)) return false;
        if (string.IsNullOrWhiteSpace(TxtPassword.Text)) return false;
        return true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        string email = Preferences.Get("email", "");
        if (!string.IsNullOrWhiteSpace(email))
        {
            TxtEmail.Text = email;
        }

        TxtPassword.Text = string.Empty;
    }

    private void LblRegisterTapped_OnTapped(object? sender, TappedEventArgs e)
    {
        Shell.Current.Navigation.PushAsync(new RegisterPage(), true);
    }

    private void LblForgotPasswordTapped_OnTapped(object? sender, TappedEventArgs e)
    {
        Shell.Current.Navigation.PushAsync(new ForgotPasswordPage(), true);
    }
}