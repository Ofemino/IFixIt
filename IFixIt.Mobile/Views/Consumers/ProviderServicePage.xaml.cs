using ServiceProvider = IFixIt.Mobile.Models.ServiceProvider;

namespace IFixIt.Mobile.Views.Consumers;

public partial class ProviderServicePage
{
    public ServiceProvider selectedSp { get; set; } = new();
    private readonly ServiceProvidedModel _selectedSp;

    public ProviderServicePage(ServiceProvider selectedSp)
    {
        this.selectedSp = selectedSp;
        InitializeComponent();
        _pageViewModel = new();
        BindingContext = _pageViewModel;

        Title = this.selectedSp.companyName;
        ServiceImg.Source = this.selectedSp.imageUrl1;
        LocationLbl.Text = this.selectedSp.address;
        DistanceLbl.Text = this.selectedSp.distance.ToString();
        CategoryLbl.Text = this.selectedSp.category;
        SubCategoryLbl.Text = this.selectedSp.subCategory;

        CategoryTypeListCv.ItemsSource = this.selectedSp.categoryTypeList1;
        DescriptionLbl.Text = this.selectedSp.description;
        // LastSeenLbl.Text = this.selectedSp.lastSeen;

        // ServiceProviderFeedbackCv.ItemsSource = _selectedSp.ServiceProviderFeedbackList;
    }

    private ProviderServicePageViewModel _pageViewModel;

    public ProviderServicePage(ServiceProvidedModel selectedSp)
    {
        InitializeComponent();
        _selectedSp = selectedSp;
        _pageViewModel = new();
    }

    private void BtnRequestJobCatalog_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new RequestJobCatalog(selectedSp.id), true);
        // Shell.Current.Navigation.PushAsync(new RequestJobCatalog(selectedSp.id), true);
    }

    private void BtnViewProfile_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.Navigation.PushAsync(new ServiceProviderProfilePage(selectedSp.id), true);
    }

    private void BtnRequestJob_OnClicked(object? sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new RequestAJobPage(selectedSp.id), true);
        // Shell.Current.Navigation.PushAsync(new RequestAJobPage(selectedSp.id), true);
    }
}