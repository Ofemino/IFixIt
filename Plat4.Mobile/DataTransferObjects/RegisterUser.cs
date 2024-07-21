namespace Plat4.Mobile.DataTransferObjects;

public class RegisterUser
{
    public int id { get; set; }
    public string fullname { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string refferalCode { get; set; }
    public bool isAgreed { get; set; }
    public string model { get; set; }
    public string manufacturer { get; set; }
    public string name { get; set; }
    public string osVersion { get; set; }
    public string idiom { get; set; }
    public string platform { get; set; }
    public string userDeviceType { get; set; }
    public string createdBy { get; set; }
    public string roles { get; set; }
}