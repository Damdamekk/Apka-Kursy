using Apka_Kursy.Entities;
using Apka_Kursy.Exceptions;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Apka_Kursy.Controllers;

[Route("api/image")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    { 
        if (file == null || file.Length == 0)
            throw new BadRequestException("The file is empty");

        var result = await _imageService.UploadImage(file);

        return Ok(result);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        try { 
            var image = await _imageService.GetImage(id);
        
            return File(image.Data, "image/jpeg");
        } 
        catch (ImageNotFoundException ex)
        {
        throw new BadRequestException("File not found.");
        }     
    }
}