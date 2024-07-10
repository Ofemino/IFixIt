namespace IFixIt.Mobile.ViewModels;

// [QueryProperty(nameof(Models.RegisterModel), "registerModel")]
public partial class RegisterViewModel : ObservableObject
{
    private readonly RegisterServices _registerServices;
    [ObservableProperty] RegisterModel registerModel;

    public RegisterViewModel(RegisterServices registerServices)
    {
        _registerServices = registerServices;
    }

    [RelayCommand]
    async void SignUpClick()
    {
        int response = await _registerServices.DoSignUpClick(registerModel);
    }
}