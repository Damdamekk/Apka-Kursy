using Apka_Kursy.Entities;
using Apka_Kursy.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apka_Kursy.Services;

public class ImageService : IImageService
{
    private readonly Apka_KursyDBContext _context;

    public ImageService(Apka_KursyDBContext context)
    {
        _context = context;
    }

    public async Task<int> UploadImage(IFormFile file)
    {
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);

        var image = new Image
        {
            Name = file.FileName,
            Data = stream.ToArray()
        };

        _context.Images.Add(image);
       var result =  await _context.SaveChangesAsync();

       if (result <= 0)
           throw new BadRequestException("Can't save the image");
       
       return image.Id;
    }
    public async Task<Image> GetImage(int id)
    {
        var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == id);

        if (image == null)
            throw new NotFoundException($"Image with id: {id} not found");

        return image;
    }
}