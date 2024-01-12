using Apka_Kursy.Entities;
using Apka_Kursy.Models;
using Microsoft.EntityFrameworkCore;

namespace Apka_Kursy.Services;

public class CourseService : ICoursesService
{
    private readonly Apka_KursyDBContext _context;

    public CourseService(Apka_KursyDBContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateCourse(CourseModel courseModel)
    {
        var course = new Course() // todo to na razie na sztywno, mozliwe ze cos tu trzeba bedzie dopasowac.
        {
            SignupMessageId = courseModel.SignupMessageId,
            CourseCategoryId = courseModel.CourseCategoryId,
            Title = courseModel.Title,
            Price = courseModel.Price,
            Description = courseModel.Description,
            CreatedAt = courseModel.CreatedAt,
            Signups = courseModel.Signups,
            Lessons = courseModel.Lessons,
            SignupMessage = courseModel.SignupMessage,
            CoursesCategory = courseModel.CoursesCategory,
            Payments = courseModel.Payments
        };

        _context.Course.Add(course);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteCourse(long courseId)
    {
        var courseToDelete = await _context.Course.SingleOrDefaultAsync(c => c.CourseId == courseId);

        if (courseToDelete is null) 
            throw new Exception("course not found");

        _context.Course.Remove(courseToDelete);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> UpdateCourse(long courseId, CourseModel dataToUpdate)
    {
        var courseToUpdate = await _context.Course.SingleOrDefaultAsync(c => c.CourseCategoryId == courseId);

        var course = new Course()
        {
            SignupMessageId = dataToUpdate.SignupMessageId,
            CourseCategoryId = dataToUpdate.CourseCategoryId,
            Title = dataToUpdate.Title,
            Price = dataToUpdate.Price,
            Description = dataToUpdate.Description,
            CreatedAt = dataToUpdate.CreatedAt,
            Signups = dataToUpdate.Signups,
            Lessons = dataToUpdate.Lessons,
            SignupMessage = dataToUpdate.SignupMessage,
            CoursesCategory = dataToUpdate.CoursesCategory,
            Payments = dataToUpdate.Payments
        };

        courseToUpdate = course;

        _context.Entry(courseToUpdate).State = EntityState.Modified;
        var result = await _context.SaveChangesAsync();
        
        return result > 0;
    }

    public async Task<CourseDto> GetCourse(long courseId)
    {
        var course = await _context.Course.SingleOrDefaultAsync(c => c.CourseId == courseId);

        if (course is null) 
             throw new Exception("course not found");

        var courseDto = new CourseDto()
        {
            Id = course.CourseId,
            Title = course.Title,
            Description = course.Description,
            Images = new List<Image>(), //todo trzeba zrobic jakas relacje zdjec z kursami.
            Price = course.Price,
        };

        return courseDto;
    }
    public async Task<List<CourseDto>> GetAllCourses()
    {
        var courses = await _context.Course.OrderBy(x => x.CourseId).ToListAsync();

        var dtos = new List<CourseDto>();

        foreach (var course in courses)
        {
            dtos.Add(new CourseDto()
            {
                Id = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                Images = new List<Image>(),
                Price = course.Price,

            });
        }

        return dtos;
    }
}