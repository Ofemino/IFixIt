namespace Plat4.Mobile.Models;

public class ChatAuthur
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
}

public class CatalogChatRequest
{
    public bool HasImage { get; set; }= false;
    public string ProviderName { get; set; }
    public string SaluteTitle { get; set; } = "Dear";
    public string RequestMessage { get; set; }
}