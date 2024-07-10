using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using IFixIt.Mobile.DataTransferObjects;
using IFixIt.Mobile.Utilities;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IFixIt.Mobile.Services;

public class LoginServices
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public LoginServices()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<int> DoLogin(UserLogin userLogin)
    {
        Uri uri = new Uri(string.Format(
            ConstantObject.BASE_URL +
            $"Auth/AppLogin/{userLogin.email}/{userLogin.password}?userType={userLogin.userType}", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                // var result = JsonSerializer.Deserialize<AppLoginResponse>(content, _serializerOptions);
                var result = JsonConvert.DeserializeObject<AppLoginResponse>(content);

                if (result.statusCode == 200)
                {
                    Preferences.Set("token", result.returnedObject.token);
                    Preferences.Set("email", result.returnedObject.userDto.email);
                    Preferences.Set("fullname", result.returnedObject.userDto.fullname);
                    Preferences.Set("userId", result.returnedObject.userDto.id);
                    Preferences.Set("userType", result.returnedObject.userDto.roles);
                    Preferences.Set("phoneNumber", result.returnedObject.userDto.roles);

                    return 1;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return 0;
        }

        return 0;
    }
}