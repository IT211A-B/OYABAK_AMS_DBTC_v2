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
        public IActionResult AddCourse([FromBody] CreateCourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Course data is null.");
            }
            var createdCourse = _courseService.CreateCourseAsync(courseDto).Result;
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.CourseId }, courseDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseByIdAsync(id).Result;
            if (course == null)
                return NotFound();
            return Ok(course);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Course data is null.");
            }
            _courseService.UpdateCourseAsync(id, courseDto).Wait();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourseAsync(id).Wait();
            return NoContent();

        }
        [HttpGet("teacher/{teacherId}")]
        public IActionResult GetCoursesByTeacherId(int teacherId)
        {
            var courses = _courseService.GetCoursesByTeacherIdAsync(teacherId).Result;
            return Ok(courses);
        }

        [HttpGet("student/{studentId}")]
        public IActionResult GetCoursesByStudentId(int studentId)
        {
            var courses = _courseService.GetCoursesByStudentIdAsync(studentId).Result;
            return Ok(courses);
        }

    }
}
