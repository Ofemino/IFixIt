using IFixIt.Mobile.Views.Controls;

namespace IFixIt.Mobile.ViewModels;

public partial class ServicePageViewModel(ServicePageServices servicePageServices) : ObservableObject
{
    private readonly ServicePageServices _servicePageServices = servicePageServices;

    [RelayCommand]
    void ChangeLocationClick()
    {
        MopupService.Instance.PushAsync(new ChangeLocationMopupPage());
    }

    [RelayCommand]
    void SelectServiceClick()
    {
        MopupService.Instance.PushAsync(new SelectServiceMopupPage());
    }
}