using System.Text;
using System.Text.Json;
using Plat4.Mobile.Models;
using Plat4.Mobile.Utilities;

namespace Plat4.Mobile.Services;

public interface IRegisterServices
{
    Task<int> DoSignUpClick(RegisterModel registerModel);
}
public class RegisterServices:IRegisterServices
{
    private readonly HttpClient _client;

    public RegisterServices(HttpClient client)
    {
        _client = client;
    }

    public async Task<int> DoSignUpClick(RegisterModel registerModel)
    {
        Uri uri = new Uri(string.Format(
            ConstantObject.BASE_URL +
            $"AppUser/CreateUser"));
        var registerData = new UserRegistration
        {
            Email = registerModel.Email, PhoneNumber = registerModel.PhoneNumber, TxtFullname = registerModel.Fullname,
            TxtPassword = registerModel.Password, TxtReferralCode = registerModel.ReferralCode,
        };

        using StringContent jsonContent =
            new(JsonSerializer.Serialize(registerModel), Encoding.UTF8, "application/json");
        var respose = await _client.PostAsync(uri, jsonContent, default);

        return 0;
    }
}