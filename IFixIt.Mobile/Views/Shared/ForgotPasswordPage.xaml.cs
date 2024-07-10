namespace IFixIt.Mobile.Views.Shared;

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