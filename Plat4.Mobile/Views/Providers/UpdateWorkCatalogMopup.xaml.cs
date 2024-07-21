namespace Plat4.Mobile.Views.Providers;

public partial class UpdateWorkCatalogMopup
{
    public UpdateWorkCatalogMopup()
    {
        InitializeComponent();
    }

    private void BtnCloseChangeLocation_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}