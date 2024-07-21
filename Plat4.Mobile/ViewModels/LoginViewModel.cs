using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Consumers;
using Plat4.Mobile.Views.Shared;

namespace Plat4.Mobile.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty] string email;
    [ObservableProperty] string password;
    [ObservableProperty] string userType;
    private LoginServices _loginServices;

    public LoginViewModel(LoginServices loginServices)
    {
        _loginServices = loginServices;
    }

    [RelayCommand]
    async void LoginClick()
    {
        var result = 1;
        if (result > 0)
            App.Current.MainPage = new HomePage();
    }

    [RelayCommand]
    void ForgotPasswordTap()
    {
        Shell.Current.Navigation.PushAsync(new ForgotPasswordPage(email), true);
    }

    [RelayCommand]
    void RegisterTap()
    {
        Shell.Current.Navigation.PushAsync(new RegisterPage(), true);
    }
}