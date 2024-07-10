namespace IFixIt.Mobile.ViewModels;

public partial class ProvidersJobRequestViewModel:ObservableObject
{
    public JobRequestService JobRequestService;
    public ObservableCollection<ProvidersJobRequestModel> JobRequestList { get; set; } = new();
    [ObservableProperty] JobRequestViewModels selectedJobRequest;
    [ObservableProperty] string selectedJobRequestFilter;

    public ProvidersJobRequestViewModel()
    {
        JobRequestService = new JobRequestService();
        LoadJobRequestList();
    }

    async Task LoadJobRequestList()
    {
        var jobs = await JobRequestService.GetProviderJobRequestList();
        foreach (var job in jobs)
        {
            JobRequestList.Add(job);
        }
    }
}