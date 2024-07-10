namespace IFixIt.Mobile.Models;

public class RegisterModel
{
    public string Fullname { get; set; }
    public string ReferralCode { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string DeviceType { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string? Name { get; set; }
    public string? OsVersion { get; set; }
    public string? Idiom { get; set; }
    public string? Platform { get; set; }
}