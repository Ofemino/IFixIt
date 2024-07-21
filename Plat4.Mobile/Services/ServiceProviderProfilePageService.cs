using System.Diagnostics;
using Newtonsoft.Json;
using Plat4.Mobile.DataTransferObjects;
using Plat4.Mobile.Models;
using Plat4.Mobile.Utilities;

namespace Plat4.Mobile.Services;

public class ServiceProviderProfilePageService
{
    public HttpClient _client { get; set; }

    public ServiceProviderProfilePageService()
    {
        _client = new HttpClient();
    }

    public async Task<ServiceProviderProfileModel> GetProviderProfile(int id)
    {
        ServiceProviderProfileModel providerProfile = new ServiceProviderProfileModel();
        Uri uri = new Uri(string.Format(
            ConstantObject.BASE_URL + $"ServiceProviders/GetProviderById/{id}", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CustomResponse<ServiceProviderProfileModel>>(content);
                if (result.StatusCode == 200)
                {
                    providerProfile = result.ReturnedObject;
                    return providerProfile;
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