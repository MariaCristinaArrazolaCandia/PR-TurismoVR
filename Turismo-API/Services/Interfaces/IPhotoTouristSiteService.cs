namespace Turismo_API.Services.Interfaces
{
    public interface IPhotoTouristSiteService
    {
        Task<List<string>> UploadImages(List<string> images, string name);
    }
}
