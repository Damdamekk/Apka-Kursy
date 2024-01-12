using Apka_Kursy.Models;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apka_Kursy.Controllers;

[Authorize(Roles = "Admin")]
[Authorize(Roles = "Nauczyciel")]
[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICoursesService _coursesService;

    public CourseController(ICoursesService coursesService)
    {
        _coursesService = coursesService;
    }
    
    [HttpGet("get/{id}")]
    public async Task<ActionResult> GetCourse([FromRoute] long id)
    {
        var course = await _coursesService.GetCourse(id);
        return Ok(course);
    }
    
    [HttpGet("get")]
    public async Task<ActionResult> GetAllCourses() //TODO trzeba bedzie zrobic paginacje
    {
        var courses = await _coursesService.GetAllCourses();
        
        if (courses.Count < 1)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        return Ok(courses);
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateCourse([FromBody] CourseModel dto)
    {
        var createCourseResult = await _coursesService.CreateCourse(dto);

        if (!createCourseResult)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        return Ok(createCourseResult);
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ActionResult> DeleteCourse([FromRoute] long id)
    {
        var deleteResult = await _coursesService.DeleteCourse(id);

        if (!deleteResult)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        return Ok();
    }
    
    [HttpPut("update/{id}")]
    public async Task<ActionResult> UpdateCourse([FromRoute] long id, [FromBody] CourseModel dto)
    {
        var updateResult = await _coursesService.UpdateCourse(id, dto);

        if (!updateResult)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        return Ok();
    }
}

public class CourseModel //todo musimy ustalic jakie dane beda potrzebne do utworzenia kursu (najprawdopodobniej beda to te co w tabeli).
{
}