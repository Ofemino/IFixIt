using Newtonsoft.Json;


namespace IFixIt.Mobile.DataTransferObjects;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class CustomResponse<T>
{
    public List<T>? ReturnedObjects { get; set; }
    public T? ReturnedObject { get; set; }
    public int StatusCode { get; set; }
    public bool HasError { get; set; }
    public string? Message { get; set; }
}

[JsonObject]
public class CategoryTypeResp
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
}

public class ServiceCategoryResp
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("fullName")] public string FullName { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("serviceSubCategories")] public List<ServiceSubCategoryResp> ServiceSubCategories { get; set; }
}

public class ServiceCategoryResponse
{
    [JsonProperty("returnedObjects")] public List<ServiceCategoryResp> ReturnedObjects { get; set; }

    [JsonProperty("returnedObject")] public object ReturnedObject { get; set; }

    [JsonProperty("statusCode")] public int? StatusCode { get; set; }

    [JsonProperty("hasError")] public bool? HasError { get; set; }

    [JsonProperty("message")] public object Message { get; set; }
}

public class ServiceSubCategoryResp
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("fullName")] public string FullName { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("categoryTypes")] public List<CategoryTypeResp> CategoryTypes { get; set; }
}