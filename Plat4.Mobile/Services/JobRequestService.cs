using Plat4.Mobile.Models;

namespace Plat4.Mobile.Services;

public class JobRequestService
{
    public List<JobRequestModel> JobRequestList =
    [
        new JobRequestModel
        {
            Id = 1, ProviderName="Joe Freeze Pipes", Category = "Home repair and Maintenance", SubCategory = "Plumbing",
            CategoryTypes = string.Join(", ", ["Pipeline and sewage ", "Borehole drilling"]), JobStatus = "Ongoing",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "ongoing_job.png"
        },
        new JobRequestModel
        {
            Id = 1, ProviderName="Enterprise Mechanics", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Completed",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "completed_job.png"
        },
        new JobRequestModel
        {
            Id = 1, ProviderName="Bahdex Autos", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Cancelled",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "cancelled_job.png"
        },
        new JobRequestModel
        {
            Id = 1, ProviderName="Enterprise Mechanics", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Rejected",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "rejected_job.png"
        },
        new JobRequestModel
        {
            Id = 1, ProviderName="TJ Auto Care", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Rejected",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "rejected_job.png"
        },
    ];


    public List<ProvidersJobRequestModel> ProvidersJobRequestList =
    [
        new ProvidersJobRequestModel
        {
            Id = 1,
            ProviderName="Joe Freeze Pipes",
            Category = "Home repair and Maintenance",
            SubCategory = "Plumbing",
            CategoryTypes = string.Join(", ", ["Pipeline and sewage ", "Borehole drilling"]),
            JobStatus = "Ongoing",
            Location = "2, Ajose Adeogun",
            RequestDateTime = DateTime.Now,
            ImageUrl = "ongoing_job.png"
        },
        new ProvidersJobRequestModel
        {
            Id = 1, ProviderName="Enterprise Mechanics", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Completed",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "completed_job.png"
        },
        new ProvidersJobRequestModel
        {
            Id = 1, ProviderName="Bahdex Autos", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Cancelled",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "cancelled_job.png"
        },
        new ProvidersJobRequestModel
        {
            Id = 1, ProviderName="Enterprise Mechanics", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Rejected",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "rejected_job.png"
        },
        new ProvidersJobRequestModel
        {
            Id = 1, ProviderName="TJ Auto Care", Category = "Auto Care and Repair", SubCategory = "Mechanic",
            CategoryTypes = string.Join(", ", ["Oil & Filter change", "Transmission"]), JobStatus = "Rejected",
            Location = "2, Ajose Adeogun", RequestDateTime = DateTime.Now, ImageUrl = "rejected_job.png"
        },
    ];

    public async Task<List<JobRequestModel>> GetJobRequestList()
    {
        return JobRequestList;
    }


    public async Task<List<ProvidersJobRequestModel>> GetProviderJobRequestList()
    {
        return ProvidersJobRequestList;
    }
}