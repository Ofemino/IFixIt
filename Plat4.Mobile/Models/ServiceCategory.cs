namespace Plat4.Mobile.Models;

public class ServiceCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    // public List<SubCategory>? SubCategories { get; set; } = new List<SubCategory>();
}

public class SubCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    // public List<CategoryType>? CategoryTypes { get; set; } = new List<CategoryType>();
    public int CategoryId { get; internal set; }
}

public class CategoryType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SubCategoryId { get; internal set; }
}