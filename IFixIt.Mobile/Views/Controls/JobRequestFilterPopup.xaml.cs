namespace IFixIt.Mobile.Views.Controls;

public partial class JobRequestFilterPopup
{
    public JobRequestFilterPopup()
    {
        InitializeComponent();
    }

    private void BtnCloseChangeLocation_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();

    }
}