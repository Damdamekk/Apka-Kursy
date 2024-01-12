using Apka_Kursy.Controllers;
using Apka_Kursy.Entities;
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
        //_context.Courses.Add(courseModel);
        var result =  await _context.SaveChangesAsync();
       
        return result > 0;
    }

    public async Task<bool> DeleteCourse(long courseId)
    {
        //var courseToDelete = await _context.Courses.SingleOrDefaultAsync(c => c.id == courseId);
        //_context.Courses.Remove(courseToDelete);

        var result =  await _context.SaveChangesAsync();
       
        return result > 0;
    }

    public async Task<bool> UpdateCourse(long courseId, CourseModel dataToUpdate)
    {
        //var courseToUpdate = await _context.Courses.SingleOrDefaultAsync(c => c.id == courseId);
        //courseToUpdate = dataToUpdate - TODO to trzeba bedzie zmapowac
        
        //_context.Entry(Courses).State = EntityState.Modified;
        var result = await _context.SaveChangesAsync();
        return result > 0; 
    }

    public async Task<CourseDto> GetCourse(long courseId)
    {
        //var course = _context.Courses.SingleOrDefaultAsync(c => c.id == courseId);
        
        // if(course is null);
        //throw new Exception("course not found");

        //return course;

        throw new NotImplementedException();
    }
    public async Task<List<CourseDto>> GetAllCourses()
    {
        /*var courses = await _context.Courses.OrderBy(x => x.id).ToListAsync();

        var dtos = new List<CourseDto>();
        
        foreach (var course in courses)
        {
         dtos.Add(new CourseDto()
         {
             Id = course.id,
             Title = course.title,
             Description = course.description,
             Images = new List<Image>(),
             Price = course.price ,
             
         });   
        }

        return dtos;*/

        throw new NotImplementedException();
    }
}