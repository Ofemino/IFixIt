using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Controls;

namespace Plat4.Mobile.ViewModels;

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