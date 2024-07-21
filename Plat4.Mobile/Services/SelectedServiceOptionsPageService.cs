using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Plat4.Mobile.Models;
using Plat4.Mobile.Utilities;
using Models_ServiceProvider = Plat4.Mobile.Models.ServiceProvider;
using ServiceProvider = Plat4.Mobile.Models.ServiceProvider;

namespace Plat4.Mobile.Services;

public class SelectedServiceOptionsPageService
{
    private readonly SelectedServiceOptions _selectOptions;

    public List<Models_ServiceProvider> ServiceProvidersList =
    [
        // new ServiceProvidedModel
        // {
        //     Id = 1,
        //     Name = "WoodEx Sewage",
        //     ServiceProviderId  = 1,
        //     IsPromoted = true,
        //     Category = "Home repair and Maintenance",
        //     SubCategory = "Masonry and Building",
        //     CategoryTypeList1 = ["Moulding and Millwork", "Builder", "Masonry"],
        //     Picture = "capentary.jpeg",
        //     Rating = 4.0,
        //     Description = "Lorem ispnum candle Lorem ispnum candle Lorem ispnum candle",
        //     Distance = 3.4,
        //     Location = "13, Aregbeshola Street Ketu",
        //     ImageUrl1 =
        //         "https://previews.123rf.com/images/andreypopov/andreypopov1607/andreypopov160700220/60368590-young-african-male-plumber-repairing-sink-in-bathroom.jpg"
        // },
        // new ServiceProvidedModel
        // {
        //     Id = 2, Name = "Pretty Plumber",
        //     Category = "Home repair and Maintenance",
        //     SubCategory = "Plumbing",
        //     CategoryTypeList1 = ["Pipeline and sewage", "Water Heater and water pumps", "Borehole drilling"],
        //     Picture = "blackman_plumbing.jpeg",
        //     Rating = 4.0,
        //     Description = "Lorem ispnum candle Lorem ispnum candle Lorem ispnum candle",
        //     Distance = 3.4,
        //     Location = "10, Barbington Av, Ikosi",
        //     ImageUrl1 =
        //         "https://previews.123rf.com/images/hryshchyshen/hryshchyshen2311/hryshchyshen231101591/221474780-african-american-plumber-installs-or-change-water-filter-replacement-aqua-filter.jpg"
        // },
        // new ServiceProvidedModel
        // {
        //     Id = 3, Name = "Plumbing Solutions",
        //     Category = "Home repair and Maintenance",
        //     SubCategory = "Plumbing",
        //     CategoryTypeList1 = ["Pipeline and sewage", "Water Heater and water pumps", "Borehole drilling"],
        //     Picture =
        //         "https://img.favpng.com/16/10/20/cartoon-handyman-stock-illustration-illustration-png-favpng-Ei8DJ5NngL2JrPXkJNbfzLkrg.jpg",
        //     Rating = 4.0,
        //     Description = "Lorem ispnum candle Lorem ispnum candle Lorem ispnum candle",
        //     Distance = 3.4,
        //     Location = "62, Ikorodu Road, Ojota Lagos",
        //     ImageUrl1 =
        //         "https://previews.123rf.com/images/andreypopov/andreypopov1607/andreypopov160700220/60368590-young-african-male-plumber-repairing-sink-in-bathroom.jpg"
        // },
        // new ServiceProvidedModel
        // {
        //     Id = 4, Name = "Phemware Pipes",
        //     Category = "Home repair and Maintenance",
        //     SubCategory = "Plumbing",
        //     CategoryTypeList1 = ["Pipeline and sewage", "Water Heater and water pumps", "Borehole drilling"],
        //     Picture =
        //         "https://img.favpng.com/16/10/20/cartoon-handyman-stock-illustration-illustration-png-favpng-Ei8DJ5NngL2JrPXkJNbfzLkrg.jpg",
        //     Rating = 4.0,
        //     Description = "Lorem ispnum candle Lorem ispnum candle Lorem ispnum candle",
        //     Distance = 3.4,
        //     Location = "3, badagry Road, Ikorodu",
        //     ImageUrl1 =
        //         "https://previews.123rf.com/images/estradaanton/estradaanton1902/estradaanton190200384/118702022-man-in-uniform-work-in-kitchen-under-sink-he-repair-water-leaking-hose-and-tools-on-floor-opened.jpg"
        // },
        // new ServiceProvidedModel
        // {
        //     Id = 5, Name = "Enterprise Mechanics",
        //     Category = "Mechanic",
        //     SubCategory = "Transmission",
        //     CategoryTypeList1 = ["Axle and Clutch Repair", "Replace and Rebuilt", "Service and Maintenance"],
        //     Picture = "mechanic_at_work_01.jpeg",
        //     Rating = 4.0,
        //     Description = "Lorem ispnum candle Lorem ispnum candle Lorem ispnum candle",
        //     Distance = 2.4,
        //     Location = "234, Ikorodu Road, Iyano School",
        //     ImageUrl1 =
        //         "https://previews.123rf.com/images/ufabizphoto/ufabizphoto2011/ufabizphoto201100458/158579889-repairing-in-action-hardworking-guy-employee-in-uniform-works-in-the-automobile-salon-confident-auto.jpg"
        // },
        // new ServiceProvidedModel
        // {
        //     Id = 6, Name = "Bahdex Auto Care",
        //     Category = "Mechanic",
        //     SubCategory = "Oil & Filter change",
        //     CategoryTypeList1 = [],
        //     Picture = "mechanic_at_work.jpeg",
        //     Rating = 4.0,
        //     Description = "Lorem ispnum candle Lorem ispnum candle Lorem ispnum candle",
        //     Distance = 3.4,
        //     Location = "104, Ikorodu Road, Kosofe Lagos",
        //     ImageUrl1 =
        //         "https://previews.123rf.com/images/fabrikacrimea/fabrikacrimea2312/fabrikacrimea231201251/220966551-young-african-mechanic-in-uniform-working-under-the-car-in-car-service-center.jpg"
        // },
    ];


    public List<ServiceProviderFeedbacks> ServiceProviderFeedbackList = [];
    private HttpClient _client;

    public SelectedServiceOptionsPageService()
    {
        _client = new HttpClient();
    }

    public async Task<List<Models_ServiceProvider>> GetSelectedServiceOption(
        SelectedServiceOptions opt)
    {
        Uri uri = new Uri(string.Format(
            ConstantObject.BASE_URL + "JobRequest/PostJobRequest", string.Empty));
        try
        {
            var loc = await GetCachedLocation();
            var pLoad = new JobRequestPayload
            {
                Long = loc.Longitude, Lat = loc.Latitude,
                CategoryTypes = "", CategoryId = opt.CategoryId, SubCategoryId = opt.SubCategoryId,
                ConsumerEmail = opt.Email, RequestDateTime = DateTimeOffset.Now
            };

            var payload = JsonConvert.SerializeObject(pLoad);
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _client.PostAsync(uri, httpRequestMessage.Content);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceProvidedModel>(content);
                if (result.statusCode == 200)
                {
                    var result1 = result.returnedObject;

                    ServiceProvidersList = result1.serviceProviders.ToList();

                    return ServiceProvidersList;
                }

                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }


        return ServiceProvidersList;
    }

    public async Task<Models_ServiceProvider?> GetSelectedServiceOptionById(int id)
    {
        return ServiceProvidersList.FirstOrDefault(i => i.id == id);
    }

    public async Task<List<ServiceProviderFeedbacks>> GetServiceProviderFeedbacks(int id)
    {
        return ServiceProviderFeedbackList;
    }


    public async Task<Location> GetCachedLocation()
    {
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
                return location;
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }

        return null;
    }
}