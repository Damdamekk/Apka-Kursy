using Apka_Kursy.Entities;

namespace Apka_Kursy.Services;

public interface IImageService
{
    Task<Image> GetImage(int id);
    Task<int> UploadImage(IFormFile file);
}