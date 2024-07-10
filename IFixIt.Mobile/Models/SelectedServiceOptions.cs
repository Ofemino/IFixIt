namespace IFixIt.Mobile.Models;

public class SelectedServiceOptions
{
    public string CategoryNames { get; set; }
    public string CategoryId { get; set; }
    public string SubCategoryId { get; set; }
    public string Email { get; set; }
}

public class JobRequestPayload
{
    public double Long { get; set; }
    public double Lat { get; set; }
    public string? ConsumerEmail { get; set; }
    public DateTimeOffset RequestDateTime { get; set; }
    public string CategoryTypes { get; set; }
    public string? SubCategoryId { get; set; }
    public string? CategoryId { get; set; }
}

public class CategoryTypeDto
{
    public string Name { get; set; }
}