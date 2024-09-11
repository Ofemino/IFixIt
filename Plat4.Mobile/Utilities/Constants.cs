namespace Plat4.Mobile.Utilities;

public static class ConstantObject
{
    // public static string BASE_URL = "https://plat4app.com/api/";
    // public static string BASE_URL = "http://localhost:5216/api/"; //"https://localhost:7186/api/";
    public static string BASE_URL = DeviceInfo.Platform == DevicePlatform.Android
        ? "http://10.0.2.2:5216/api/"
        : "http://localhost:5216/api"; //
}