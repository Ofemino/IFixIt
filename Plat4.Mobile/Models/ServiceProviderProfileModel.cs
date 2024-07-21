namespace Plat4.Mobile.Models;


public class ServiceProviderProfileDto
{
    public List<ServiceProviderProfileModel> returnedObjects { get; set; }
    public ServiceProviderProfileModel returnedObject { get; set; }
    public int statusCode { get; set; }
    public bool hasError { get; set; }
    public object message { get; set; }
}

public class ServiceProviderProfileModel
{
    public int id { get; set; }
    public string companyName { get; set; }
    public string phoneNumber { get; set; }
    public string emailAddress { get; set; }
    public object category { get; set; }
    public string? address { get; set; }
    public object subCategory { get; set; }
    public object rating { get; set; }
    public object imageUrl1 { get; set; }
    public object categoryTypeList1 { get; set; }
    public string ongoingJobsStr { get; set; }
    public string completedJobsStr { get; set; }
    public string cancelledJobsStr { get; set; }
    public string rejectedJobsStr { get; set; }
    public string location { get; set; }
    public string isPromoted { get; set; }
    public bool isDeleted { get; set; }
    public string isVerified { get; set; }
    public int distance { get; set; }
    public WorkingHour workingHour { get; set; }
    public object picture { get; set; }
    public object description { get; set; }
}

