using System.Collections;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;
using Plat4.Mobile.DataTransferObjects;
using Plat4.Mobile.Utilities;

namespace Plat4.Mobile.Services;

public class ServicePageServices
{
    // private List<ServiceCategory> CategoryList =
    // [
    //     new ServiceCategory
    //     {
    //         Id = 1, Name = "Home repair and Maintenance", Description = "Home repair and Maintenance",
    //     },
    //     new ServiceCategory
    //     {
    //         Id = 2, Name = "Auto Care and Repair", Description = "Auto Care and Repair",
    //     }
    // ];

    // private List<SubCategory> SubCategoryList =
    // [
    //     new SubCategory
    //     {
    //         Id = 1, CategoryId = 1, Name = "Plumbing", Description = "Plumbing"
    //     },
    //     new SubCategory
    //     {
    //         Id = 2, CategoryId = 1, Name = "Masonry and Building", Description = "Masonry and Building"
    //     },
    //     new SubCategory
    //     {
    //         Id = 3, CategoryId = 1, Name = "Cleaner", Description = "Cleaner"
    //     },
    //     new SubCategory
    //     {
    //         Id = 4, CategoryId = 1, Name = "HVAC", Description = "HVAC"
    //     },
    //     new SubCategory
    //     {
    //         Id = 5, CategoryId = 1, Name = "Roofing and Repair", Description = "Roofing and Repair"
    //     },
    //     new SubCategory
    //     {
    //         Id = 6, CategoryId = 1, Name = "Carpentry", Description = "Carpentry"
    //     },
    //     new SubCategory
    //     {
    //         Id = 7, CategoryId = 1, Name = "Flooring and Carpet Installation",
    //         Description = "Flooring and Carpet Installation"
    //     },
    //     new SubCategory
    //     {
    //         Id = 8, CategoryId = 1, Name = "Security Camera Installation", Description = "Security Camera Installation"
    //     },
    //     new SubCategory
    //     {
    //         Id = 9, CategoryId = 1, Name = "Kitchen Design", Description = "Kitchen Design"
    //     },
    //     new SubCategory
    //     {
    //         Id = 10, CategoryId = 1, Name = "Painter", Description = "Painter"
    //     },
    //     new SubCategory
    //     {
    //         Id = 11, CategoryId = 2, Name = "Mechanic", Description = "Mechanic"
    //     }
    // ];
    //
    // private List<CategoryType> CategoryTypeList =
    // [
    //     new CategoryType()
    //         { Id = 1, SubCategoryId = 1, Name = "Pipeline and Sewage", Description = "Pipeline and Sewage" },
    //     new CategoryType()
    //     {
    //         Id = 2, SubCategoryId = 1, Name = "Water Heater and water pumps",
    //         Description = "Water Heater and Water Pumps"
    //     },
    //     new CategoryType()
    //         { Id = 3, SubCategoryId = 1, Name = "Borehole Drilling", Description = "Borehole Drilling" },
    //     new CategoryType()
    //     {
    //         Id = 4, SubCategoryId = 2, Name = "Moulding and MillWorks",
    //         Description = "Moulding and MillWorks"
    //     },
    //     new CategoryType()
    //     {
    //         Id = 5, SubCategoryId = 2, Name = "Builder",
    //         Description = "Builder"
    //     },
    //     new CategoryType()
    //         { Id = 6, SubCategoryId = 2, Name = "Masonry", Description = "Masonry" },
    //     new CategoryType()
    //         { Id = 7, SubCategoryId = 11, Name = "Oil & Filter change", Description = "Oil & Filter change" },
    //     new CategoryType()
    //     {
    //         Id = 8, SubCategoryId = 11, Name = "Transmission ",
    //         Description = "Axle and Clutch Repair - Replace and Rebuilt - Service and Maintenance"
    //     },
    //     new CategoryType()
    //     {
    //         Id = 9, SubCategoryId = 11, Name = "Engine Services",
    //         Description =
    //             "Repair and Replace - Belt, Hose and Radiator Replacement - Service and Computer Diagnostic"
    //     },
    // ];

    private HttpClient _client;

    // private JsonSerializerOptions _serializerOptions;
    private List<ServiceCategoryResp> _serviceCategories;
    private ServiceCategoryResp? _serviceCategory;
    private List<ServiceSubCategoryResp>? _serviceSubCategory;
    private ServiceSubCategoryResp? _serviceSubCategoryType;
    public List<CategoryTypeResp>? _serviceCategoryTypes;

    public ServicePageServices()
    {
        _serviceCategories = new List<ServiceCategoryResp>();
        _serviceCategory = new ServiceCategoryResp();
        _serviceCategoryTypes = new List<CategoryTypeResp>();
        _client = new HttpClient();
        // _serializerOptions = new JsonSerializerOptions
        // {
        //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //     WriteIndented = true
        // };
    }

    public async Task<List<ServiceCategoryResp>> GetServiceCategoryList()
    {
        Uri uri = new Uri(string.Format(
            ConstantObject.BASE_URL + "ServiceCategory/GetAllServiceCategories", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CustomResponse<ServiceCategoryResp>>(content);
                if (result.StatusCode == 200)
                {
                    var result1 = result.ReturnedObjects;

                    _serviceCategories = result1;

                    return _serviceCategories;
                }

                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }


        return null;
    }

    public List<ServiceSubCategoryResp> GetServiceSubCategoryList(int id)
    {
        _serviceCategory = _serviceCategories
            .FirstOrDefault(i => i.Id == id);
        if (_serviceCategory.ServiceSubCategories != null)
            return _serviceCategory.ServiceSubCategories.ToList();
        return new List<ServiceSubCategoryResp>();
    }

    public List<CategoryTypeResp> GetServiceCategoryTypeList(int id)
    {
        _serviceSubCategoryType = _serviceCategory.ServiceSubCategories
            .FirstOrDefault(i => i.Id == id);
        if (_serviceSubCategoryType.CategoryTypes != null)
            return _serviceSubCategoryType.CategoryTypes.ToList();
        return new List<CategoryTypeResp>();
    }

    public CategoryTypeResp? GetServiceCategoryType(int id)
    {
        var categoryType = _serviceSubCategoryType.CategoryTypes.FirstOrDefault(i => i.Id == id.ToString());
        if (categoryType != null)
            return categoryType;
        return new CategoryTypeResp();
    }

    public async Task<List<CategoryTypeResp>> GetOnlyCategoryType(int id)
    {
        Uri uri = new Uri(string.Format(
            ConstantObject.BASE_URL + $"ServiceCategory/GetOnlyCategoryTypes/{id}", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CustomResponse<CategoryTypeResp>>(content);
                if (result.StatusCode == 200)
                {
                    _serviceCategoryTypes = result.ReturnedObjects;
                    return _serviceCategoryTypes;
                }
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }


        return null;
    }
}