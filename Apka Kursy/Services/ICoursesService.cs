using Apka_Kursy.Controllers;

namespace Apka_Kursy.Services;

public interface ICoursesService
{
    Task<bool> CreateCourse(CourseModel courseModel);
    Task<bool> DeleteCourse(long courseId);
    Task<bool> UpdateCourse(long courseId, CourseModel dataToUpdate);
    Task<CourseDto> GetCourse(long courseId);
    Task<List<CourseDto>> GetAllCourses();
}