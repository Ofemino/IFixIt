namespace Plat4.Mobile.Views.Providers;

public partial class UpdateWorkHourMopup
{
    private string? selectedStartTime = string.Empty;
    private string? selectedEndTime = string.Empty;

    public UpdateWorkHourMopup()
    {
        InitializeComponent();
        ButtonSaveWorkHours.IsEnabled = false;
    }

    private void BtnCloseChangeLocation_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void PickerStartTime_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        selectedStartTime = (string)picker.ItemsSource[selectedIndex];
    }

    private void PickerEndTime_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        selectedEndTime = (string)picker.ItemsSource[selectedIndex];
        if (!string.IsNullOrEmpty(selectedEndTime)) ButtonSaveWorkHours.IsEnabled = true;
    }

    private void ButtonSaveWorkHours_OnClicked(object? sender, EventArgs e)
    {
    }
}