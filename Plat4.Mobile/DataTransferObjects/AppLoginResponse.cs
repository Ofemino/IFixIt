namespace Plat4.Mobile.DataTransferObjects;

public class AppLoginResponse
{
    public ReturnedObject[] returnedObjects { get; set; }
    public ReturnedObject returnedObject { get; set; }
    public int statusCode { get; set; }
    public bool hasError { get; set; }
    public string message { get; set; }
}



