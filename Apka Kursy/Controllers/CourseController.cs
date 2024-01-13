using Apka_Kursy.Exceptions;
using Apka_Kursy.Models;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

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
        try
        {
            var course = await _coursesService.GetCourse(id);
            return Ok(course);
        } 
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("get")]
    public async Task<ActionResult> GetAllCourses() //TODO trzeba bedzie zrobic paginacje
    {
        try
        {
            var courses = await _coursesService.GetAllCourses();

            if (courses.Count < 1)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(courses);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateCourse([FromBody] CourseModel dto)
    {
        try
        {
            var createCourseResult = await _coursesService.CreateCourse(dto);

            if (!createCourseResult)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(createCourseResult);
        } catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ActionResult> DeleteCourse([FromRoute] long id)
    {
        try { 
            var deleteResult = await _coursesService.DeleteCourse(id);

            if (!deleteResult)
                return StatusCode(StatusCodes.Status500InternalServerError);
        
            return Ok();
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("update/{id}")]
    public async Task<ActionResult> UpdateCourse([FromRoute] long id, [FromBody] CourseModel dto)
    {
        try { 
            var updateResult = await _coursesService.UpdateCourse(id, dto);

            if (!updateResult)
                return StatusCode(StatusCodes.Status500InternalServerError);
        
            return Ok();
        } 
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}