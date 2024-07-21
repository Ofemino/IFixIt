using Plat4.Mobile.ViewModels;

namespace Plat4.Mobile.Views.Shared;

public partial class ForgotPasswordPage : ContentPage
{
    ForgotPasswordViewModel forgotPasswordViewModel;
    public ForgotPasswordPage()
    {
        InitializeComponent();
        BindingContext = forgotPasswordViewModel;
    }

    public ForgotPasswordPage(string email)
    {
        InitializeComponent();
        BindingContext = forgotPasswordViewModel;
    }
}