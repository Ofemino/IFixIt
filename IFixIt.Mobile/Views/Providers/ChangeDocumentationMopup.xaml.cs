namespace IFixIt.Mobile.Views.Providers;

public partial class ChangeDocumentationMopup
{
    public ChangeDocumentationMopup()
    {
        InitializeComponent();
    }

    private void BtnCloseChangeLocation_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void VotersCardTapped_OnTapped(object? sender, TappedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CacDocumentTapped_OnTapped(object? sender, TappedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DriversLicenseTapped_OnTapped(object? sender, TappedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void IdentityDocumentTapped_OnTapped(object? sender, TappedEventArgs e)
    {
        throw new NotImplementedException();
    }
}