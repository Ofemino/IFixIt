using Syncfusion.Maui.Buttons;

namespace IFixIt.Mobile.Views.Shared;

public partial class RegisterPage : ContentPage
{
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
        var response = await DoAppUserRegister();
    }

    private async Task<object> DoAppUserRegister()
    {
        throw new NotImplementedException();
    }
}