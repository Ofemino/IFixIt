namespace Plat4.Mobile.DataTransferObjects;

public class ReturnedObject
{
    public string token { get; set; }
    public UserDto userDto { get; set; }
    public string userType { get; set; }
    public string refreshToken { get; set; }
}