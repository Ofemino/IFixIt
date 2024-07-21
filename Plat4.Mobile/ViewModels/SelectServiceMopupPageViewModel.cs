using Plat4.Mobile.Models;
using Plat4.Mobile.Services;
using Plat4.Mobile.Views.Consumers;

namespace Plat4.Mobile.ViewModels;

public partial class SelectServiceMopupPageViewModel : ObservableObject
{
    private ServicePageServices _servicePageServices = new();

    public ObservableCollection<ServiceCategory> ServiceCategories { get; set; } = new();
    public ObservableCollection<SubCategory> SubCategories { get; set; } = new();
    public ObservableCollection<CategoryType> CategoryTypes { get; set; } = new();
    public ObservableCollection<string> CategoryNames { get; set; } = new();


    [ObservableProperty] ServiceCategory selectedCategory;
    [ObservableProperty] SubCategory selectedSubCategory;
    [ObservableProperty] CategoryType selectedCategoryTypes;
    [ObservableProperty] bool buttonIsEnabled = false;

    public SelectServiceMopupPageViewModel()
    {
        GetServiceCategoryList();
        // selectedCategoryTypes = new();
    }

    private async Task GetServiceCategoryList()
    {
        var serviceCategoryList = await _servicePageServices.GetServiceCategoryList();
        if (serviceCategoryList == null)
        {
            App.Current.MainPage.DisplayAlert("plat4", "Unable to get service details, check your internet", "Ok");
            MopupService.Instance.PopAsync();
        }

        foreach (var categoryItem in serviceCategoryList)
        {
            ServiceCategories.Add(new ServiceCategory { Id = categoryItem.Id, Name = categoryItem.FullName });
        }
    }


    [RelayCommand]
    void LoadSubCategoryClick()
    {
        SubCategories.Clear();
        CategoryTypes.Clear();
        CategoryNames.Clear();
        if (selectedCategory == null)
        {
            return;
        }

        var subCategories = _servicePageServices.GetServiceSubCategoryList(selectedCategory.Id);
        foreach (var category in subCategories)
        {
            SubCategories.Add(new SubCategory { Id = category.Id, Name = category.FullName });
        }
    }

    [RelayCommand]
    async Task LoadCategoryTypeClick()
    {
        CategoryTypes.Clear();
        CategoryNames.Clear();
        if (selectedSubCategory == null)
        {
            return;
        }

        var categoryTypes = await _servicePageServices.GetOnlyCategoryType(selectedSubCategory.Id);
        if (categoryTypes.Count == 0) return;
        foreach (var category in categoryTypes)
        {
            CategoryTypes.Add(new CategoryType()
            {
                Id = Convert.ToInt16(category.Id), Name = category.Name
            });
        }
    }

    [RelayCommand]
    void SelectedCategoryTypeClick()
    {
        if (selectedCategoryTypes == null) return;
        if (_servicePageServices._serviceCategoryTypes.Count == 0) return;
        var categoryTypes =
            _servicePageServices._serviceCategoryTypes
                .FirstOrDefault(c => c.Id == selectedCategoryTypes.Id.ToString());
        if (categoryTypes != null)
        {
            if (!CategoryNames.Contains(categoryTypes.Name))
            {
                CategoryNames.Add(categoryTypes.Name);
            }

            if (CategoryNames.Count > 0)
                ButtonIsEnabled = true;
        }
    }

    [RelayCommand]
    void ClearAllSelectedCategoryType()
    {
        SubCategories.Clear();
        CategoryTypes.Clear();
        CategoryNames.Clear();

        ButtonIsEnabled = false;
    }

    [ObservableProperty] SelectedServiceOptions selectedServiceOptions;

    [RelayCommand]
    void SearchForProviderClick()
    {
        var selectOptions = new SelectedServiceOptions
        {
            CategoryNames = CategoryNames[0],
            SubCategoryId = selectedSubCategory.Id.ToString(),
            CategoryId = selectedCategory.Id.ToString()

        };
        MopupService.Instance.PopAsync();
        // Shell.Current.GoToAsync($"{nameof(SelectedServiceOptionsPage)}", new Dictionary<string, object>
        // {
        //     { "serviceOptions", selectOptions }
        // });
        Shell.Current.Navigation.PushAsync(new SelectedServiceOptionsPage(selectOptions), true);
    }
}