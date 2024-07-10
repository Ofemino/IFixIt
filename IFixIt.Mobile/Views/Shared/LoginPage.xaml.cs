using IFixIt.Mobile.DataTransferObjects;
using IFixIt.Mobile.Views.Consumers;
using SelectionChangedEventArgs = Syncfusion.Maui.Buttons.SelectionChangedEventArgs;

namespace IFixIt.Mobile.Views.Shared;

public partial class LoginPage : ContentPage
{
    public int SegmentButtonSelectedIndex { get; set; } = 0;
    private LoginServices _loginServices = new();

    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
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
}