namespace IFixIt.Mobile.Views.Controls;

public partial class SelectServiceMopupPage
{
    private readonly SelectServiceMopupPageViewModel _serviceMopupPageViewModel = new();



    public SelectServiceMopupPage()
    {
        InitializeComponent();
        BindingContext = _serviceMopupPageViewModel;
    }

    private void BtnCloseSelectServices_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}