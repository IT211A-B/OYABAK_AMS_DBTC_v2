using Microsoft.AspNetCore.Mvc;
using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Services.Interface;

namespace AMS_DBTC_API_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCourse([FromBody] CreateCourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Course data is null.");
            }
            var createdCourse = _courseService.CreateCourseAsync(courseDto).Result;
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.CourseId }, courseDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Course data is null.");
            }
            await _courseService.UpdateCourseAsync(id, courseDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();

        }
        [HttpGet("teacher/{teacherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCoursesByTeacherId(int teacherId)
        {
            var courses = await _courseService.GetCoursesByTeacherIdAsync(teacherId);
            return Ok(courses);
        }

        [HttpGet("student/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCoursesByStudentId(int studentId)
        {
            var courses = await _courseService.GetCoursesByStudentIdAsync(studentId);
            return Ok(courses);
        }

    }
}
