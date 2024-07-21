using Plat4.Mobile.Models;
using Plat4.Mobile.Services;
using Plat4.Mobile.ViewModels;
using Models_ServiceProvider = Plat4.Mobile.Models.ServiceProvider;
using ServiceProvider = Plat4.Mobile.Models.ServiceProvider;

namespace Plat4.Mobile.Views.Consumers;

public partial class SelectedServiceOptionsPage : ContentPage
{
    private readonly SelectedServiceOptions _selectOptions;
    private Models_ServiceProvider _selectedProviderItem = null;
    public SelectedServiceOptionsPageService OptionsPageService { get; set; } = new();

    public SelectedServiceOptionsPage(SelectedServiceOptions selectOptions)
    {
        _selectOptions = selectOptions;
        InitializeComponent();
        BindingContext = new SelectedServiceOptionsViewModel();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _selectOptions.Email = Preferences.Get("email", "");
        var providers = await OptionsPageService.GetSelectedServiceOption(_selectOptions);
        if (providers.Count > 0)
        {
            providersView.ItemsSource = providers;
            providersView.SelectionChanged += (sender, args) =>
            {
                // _selectedProviderItem = (ServiceProvider)providersView.SelectedItem;
            };
        }
    }


    private void ProvidersView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        _selectedProviderItem = (Models_ServiceProvider)providersView.SelectedItem;
        if (_selectedProviderItem != null)
        {
            Shell.Current.Navigation.PushAsync(new ProviderServicePage(_selectedProviderItem), true);
        }

        _selectedProviderItem = null;
    }
}