using ServiceProvider = IFixIt.Mobile.Models.ServiceProvider;

namespace IFixIt.Mobile.Services;

public class ServiceProviderProfilePageService
{
    public ServiceProviderProfilePageService()
    {
    }

    public Task<ServiceProviderProfileModel> GetProviderProfile(int id)
    {
        try
        {
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

        return null;
    }
}