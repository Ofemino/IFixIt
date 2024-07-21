using Plat4.Mobile.Models;
using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Controls;

namespace Plat4.Mobile.ViewModels;

public partial class JobRequestViewModels : ObservableObject
{
    public JobRequestService JobRequestService;
    public ObservableCollection<JobRequestModel> JobRequestList { get; set; } = new();
    public ObservableCollection<string> JobRequestFilterList { get; set; } = new();
    [ObservableProperty] JobRequestViewModels selectedJobRequest;
    [ObservableProperty] string selectedJobRequestFilter;

    public JobRequestViewModels()
    {
        JobRequestService = new JobRequestService();
        LoadJobRequestList();
    }

    async Task LoadJobRequestList()
    {
        var jobs = await JobRequestService.GetJobRequestList();
        foreach (var job in jobs)
        {
            JobRequestList.Add(job);
        }
    }

    [RelayCommand]
    void SelectedJobRequestClick()
    {
    }

    [RelayCommand]
    void JobRequestFilerClick()
    {
        MopupService.Instance.PushAsync(new JobRequestFilterPopup(), true);
    }
}