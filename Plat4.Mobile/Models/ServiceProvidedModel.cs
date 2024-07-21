namespace Plat4.Mobile.Models;

// public class ServiceProvidedModel
// {
//     public int Id { get; set; }
//     public int ServiceProviderId { get; set; }
//     public string? Name { get; set; }
//     public string? LastSeen { get; set; }
//     public string? Location { get; set; }
//     public string? Category { get; set; }
//     public string? SubCategory { get; set; }
//     public List<string>? CategoryTypeList1 { get; set; }
//     // public string? CategoryType { get; set; }
//     public string? Picture { get; set; }
//     public string? ImageUrl1 { get; set; }
//     public double Rating { get; set; }
//     public string? Description { get; set; }
//     public double Distance { get; set; }
//
//     public List<ServiceProviderFeedbacks> ServiceProviderFeedbackList { get; set; } = new();
//     public string? PageTitle { get; set; }
//     public bool IsPromoted { get; set; }
// }


public class ServiceProvidedModel
{
    public object returnedObjects { get; set; }
    public ReturnedObject returnedObject { get; set; }
    public int statusCode { get; set; }
    public bool hasError { get; set; }
    public object message { get; set; }
}

public class ReturnedObject
{
    public JobRequest jobRequest { get; set; }
    public ServiceProvider[] serviceProviders { get; set; }
}

public class JobRequest
{
    public int id { get; set; }
    public string lon { get; set; }
    public string lat { get; set; }
    public string categoryId { get; set; }
    public string subCategoryId { get; set; }
    public object categoryTypes { get; set; }
    public string consumerEmail { get; set; }
    public string requestDateTime { get; set; }
    public string jobStatus { get; set; }
    public object statusComment { get; set; }
    public object location { get; set; }
    public object requestDateTimeTStr { get; set; }
}

public class ServiceProvider
{
    public string? address;
    public int id { get; set; }
    public string companyName { get; set; }
    public string description { get; set; }
    public string? phoneNumber { get; set; }
    public string emailAddress { get; set; }
    public string category { get; set; }
    public string subCategory { get; set; }
    public int rating { get; set; }
    public string imageUrl1 { get; set; }
    public string[] categoryTypeList1 { get; set; }
    public string ongoingJobsStr { get; set; }
    public string completedJobsStr { get; set; }
    public string cancelledJobsStr { get; set; }
    public string rejectedJobsStr { get; set; }
    public string location { get; set; }
    public string isPromoted { get; set; }
    public bool isDeleted { get; set; }
    public string isVerified { get; set; }
    public double distance { get; set; }
    public WorkingHour workingHour { get; set; }
    public string picture { get; set; }
}

public class WorkingHour
{
    public int serviceProviderId { get; set; }
    public string start { get; set; }
    public string end { get; set; }
}

