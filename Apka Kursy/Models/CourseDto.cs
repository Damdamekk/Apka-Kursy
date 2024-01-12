using Apka_Kursy.Entities;

namespace Apka_Kursy.Services;

public class CourseDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Image> Images { get; set; }
    public decimal Price { get; set; }
}