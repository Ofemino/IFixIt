namespace IFixIt.Mobile.Models;

public class JobRequestModel
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
    public string CategoryTypes { get; set; }
    public DateTime RequestDateTime { get; set; }
    public string Location { get; set; }
    public string JobStatus { get; set; }
    public string ImageUrl { get; set; }
    public string ProviderName { get; set; }
}