namespace IFixIt.Mobile.ViewModels;

public partial class ProviderProfilePageViewModel : ObservableObject
{
    [RelayCommand]
    void ChangeAddressLocationTapped()
    {
        MopupService.Instance.PushAsync(new ChangeAddressLocationMopup(), true);
    }

    [RelayCommand]
    void UpdateDocumentTapped()
    {
        MopupService.Instance.PushAsync(new ChangeDocumentationMopup(), true);
    }

    [RelayCommand]
    void UpdateWorkHourTapped()
    {
        MopupService.Instance.PushAsync(new UpdateWorkHourMopup(), true);
    }

    [RelayCommand]
    void UpdateWorkCatalogTapped()
    {
        MopupService.Instance.PushAsync(new UpdateWorkCatalogMopup(), true);
    }
}