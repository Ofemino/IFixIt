using Syncfusion.Maui.Buttons;

namespace IFixIt.Mobile.Views.Shared;

public partial class RegisterPage : ContentPage
{
    private readonly RegisterServices _registerServices = new();

    public RegisterPage(RegisterViewModel registerViewModel)
    {
        InitializeComponent();
        BindingContext = registerViewModel;
    }

    public RegisterPage()
    {
        InitializeComponent();
    }

    private void ChbIAgree_OnStateChanged(object? sender, StateChangedEventArgs e)
    {
        if (ChbIAgree.IsChecked == e.IsChecked)
        {
            BtnRegister.IsEnabled = true;
        }
        else
        {
            BtnRegister.IsEnabled = false;
        }
    }

    private async void BtnRegister_OnClicked(object? sender, EventArgs e)
    {
        if (TxtPassword.Text != TxtConfirmPassword.Text)
            DisplayAlert("Registration", "Please ensure confirm password value is the same with the password value.",
                "Ok");
        var response = await DoAppUserRegister();
        if (response == 0)
            DisplayAlert("Registration!", "Unable to process request at the moment, try again later.", "Ok");
        Preferences.Set("email", TxtEmail.Text);

        Shell.Current.GoToAsync(nameof(LoginPage), true);
    }

    private async Task<int> DoAppUserRegister()
    {
        var user = new RegisterModel
        {
            Email = TxtEmail.Text,
            PhoneNumber = TxtPhoneNumber.Text,
            Fullname = TxtFullname.Text,
            ReferralCode = TxtReferralCode.Text,
            Password = TxtPassword.Text,
            Idiom = DeviceInfo.Current.Idiom.ToString(),
            Model = DeviceInfo.Current.Model,
            DeviceType = DeviceInfo.Current.DeviceType.ToString(),
            Manufacturer = DeviceInfo.Current.Manufacturer,
            Name = DeviceInfo.Current.Name,
            Platform = DeviceInfo.Current.Platform.ToString(),
            OsVersion = DeviceInfo.Current.VersionString
        };
        var result = _registerServices.DoSignUpClick(user);

        return 0;
    }

    private void LblToc_OnTapped(object? sender, TappedEventArgs e)
    {
    }
}