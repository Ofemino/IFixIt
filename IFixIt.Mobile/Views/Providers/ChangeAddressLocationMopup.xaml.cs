namespace IFixIt.Mobile.Views.Providers;

public partial class ChangeAddressLocationMopup
{
    public ChangeAddressLocationMopup()
    {
        InitializeComponent();
    }

    private void BtnCloseChangeLocation_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void LocationTxt_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var url =
            "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=%22Ketu%22&types=geocode&key=AIzaSyBYR0GlJWTM57ZtgBLqwykH9MzlhhroWkw";
        if (e.NewTextValue.Length > 0)
        {
            string content = FileGetContents(url);
        }
    }

    protected string FileGetContents(string fileName)
    {
        string sContents = string.Empty;
        string me = string.Empty;
        try
        {
            if (fileName.ToLower().IndexOf("https:") > -1)
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] response = wc.DownloadData(fileName);
                sContents = System.Text.Encoding.ASCII.GetString(response);

            }
            else
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                sContents = sr.ReadToEnd();
                sr.Close();
            }
        }
        catch { sContents = "unable to connect to server "; }
        return sContents;
    }

}