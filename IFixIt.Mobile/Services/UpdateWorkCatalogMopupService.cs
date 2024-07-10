namespace IFixIt.Mobile.Services;

public class UpdateWorkCatalogMopupService
{
    private List<WorkCatalogImagesModel> catalogImagesList =
    [
        new WorkCatalogImagesModel
        {
            Id = 1, ImageFile = "mechanic_at_work.jpeg", NumberOfLikes = 1, NumberOfDislikes = 3, NumberOfFavorites = 1
        },
        new WorkCatalogImagesModel
        {
            Id = 2, ImageFile = "mechanic_at_work.jpeg", NumberOfLikes = 1, NumberOfDislikes = 3, NumberOfFavorites = 3
        },
        new WorkCatalogImagesModel
        {
            Id = 3, ImageFile = "mechanic_at_work.jpeg", NumberOfLikes = 1, NumberOfDislikes = 3, NumberOfFavorites = 2
        },
    ];

    public async Task<List<WorkCatalogImagesModel>> LoadWorkCatalogImages()
    {
        return catalogImagesList;
    }
}