using System.Security.Cryptography.X509Certificates;
using Plat4.Mobile.ViewModels;

namespace Plat4.Mobile.Views.Consumers;

public partial class ServicePage : ContentPage
{
    public string PinAddress { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public int UserId { get; set; }

    public ServicePage(ServicePageViewModel servicePageViewModel)
    {
        InitializeComponent();
        BindingContext = servicePageViewModel;

        UserFullName = Preferences.Get("fullname", "");
        UserEmail = Preferences.Get("email", "");
        UserId = Preferences.Get("userId", 0);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        LoadDefaultGoogleMapLocation();
        LblUserName.Text = UserFullName;
    }


    // private async Task<PermissionStatus> CheckAndRequestNetworkPermission()
    // {
    //     PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.NetworkState>();
    //     if (status == PermissionStatus.Granted)
    //         return status;
    //
    //     if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
    //     {
    //         // Prompt the user to turn on in settings
    //         // On iOS once a permission has been denied it may not be requested again from the application
    //         return status;
    //     }
    //
    //     if (Permissions.ShouldShowRationale<Permissions.NetworkState>())
    //     {
    //         // Prompt the user with additional information as to why the permission is needed
    //     }
    //
    //     status = await Permissions.RequestAsync<Permissions.NetworkState>();
    //
    //     return status;
    // }


    // private async Task<PermissionStatus> CheckAndRequestLocationPermission()
    // {
    //     PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
    //
    //     if (status == PermissionStatus.Granted)
    //         return status;
    //
    //     if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
    //     {
    //         // Prompt the user to turn on in settings
    //         // On iOS once a permission has been denied it may not be requested again from the application
    //         return status;
    //     }
    //
    //     if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
    //     {
    //         // Prompt the user with additional information as to why the permission is needed
    //     }
    //
    //     status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    //
    //     return status;
    // }

    private async Task LoadDefaultGoogleMapLocation()
    {
        try
        {
            GeolocationRequest geolocationRequest =
                new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
            var locationDetail = await Geolocation.GetLocationAsync(geolocationRequest);

            serviceMap.MoveToRegion(MapSpan.FromCenterAndRadius(locationDetail, Distance.FromMiles(3)));

            IEnumerable<Placemark> placemarks =
                await Geocoding.Default.GetPlacemarksAsync(locationDetail.Latitude, locationDetail.Longitude);
            Placemark placeMark = placemarks?.FirstOrDefault();
            if (placeMark != null)
            {
                PinAddress = placeMark.FeatureName + ", " + placeMark.Thoroughfare;
                currentLocationLbl.Text = PinAddress;
            }
            else
            {
                currentLocationLbl.Text = "";
            }

            var pin = new Pin
            {
                Address = PinAddress,
                Location = locationDetail,
                Type = PinType.Place,
                Label = "Location",
            };
            serviceMap.Pins.Add(pin);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}