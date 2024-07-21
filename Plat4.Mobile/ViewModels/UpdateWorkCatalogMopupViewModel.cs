using Plat4.Mobile.Models;
using Plat4.Mobile.Services;

namespace Plat4.Mobile.ViewModels;

public partial class UpdateWorkCatalogMopupViewModel : ObservableObject
{
    private UpdateWorkCatalogMopupService _mopupService = new();
    public ObservableCollection<WorkCatalogImagesModel> CatalogImageList { get; set; } = new();

    [ObservableProperty] WorkCatalogImagesModel selectedCatalogImagesModel;

    public UpdateWorkCatalogMopupViewModel()
    {
        LoadWorkCatalogImages();
    }

    private async Task LoadWorkCatalogImages()
    {
        var catalogs = await _mopupService.LoadWorkCatalogImages();
        if (catalogs.Any())
        {
            foreach (WorkCatalogImagesModel catalog in catalogs)
            {
                CatalogImageList.Add(catalog);
            }
        }
    }
}