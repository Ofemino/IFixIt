using System.Text.Json.Nodes;

namespace IFixIt.Mobile.Views.Controls;

public partial class ChangeLocationMopupPage
{
    public ChangeLocationMopupPage()
    {
        InitializeComponent();
    }

    private void BtnCloseChangeLocation_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();

    }

    // private void DoSearch()
    // {
    //     string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + var + "&types=geocode&key=YOURAPIKEY";
    //     string content = FileGetContents(url);
    //     var o = JsonObject.Parse(content);
    //     List<string> add = new List<string>();
    //     try
    //     {
    //         JObject jObj = (JObject)JsonConvert.DeserializeObject(content);
    //         int count = jObj.Count;
    //         for (int i = 0; i < count; i++)
    //         {
    //
    //             add.Add((string)o.SelectToken("predictions["+i+"].description"));
    //
    //
    //
    //         }
    //
    //         var collection = new AutoCompleteStringCollection();
    //         collection.AddRange(add.ToArray());
    //         textBox1.AutoCompleteCustomSource = collection;
    //         textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
    //         textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    //
    //
    //
    //     }
    //     catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    //     {
    //     }
    // }
    //
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

    private void LocationTxt_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var url =
            "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=%22Ketu%22&types=geocode&key=AIzaSyBYR0GlJWTM57ZtgBLqwykH9MzlhhroWkw";
        if (e.NewTextValue.Length > 0)
        {
            string content = FileGetContents(url);
        }
    }
}