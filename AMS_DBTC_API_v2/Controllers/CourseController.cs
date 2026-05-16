using Microsoft.AspNetCore.Mvc;
using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Services.Interface;

namespace AMS_DBTC_API_v2.Controllers
{
    /// <summary>
    /// Handles course-related operations such as creating,
    /// retrieving, updating, and deleting courses.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        /// <summary>
        /// Initializes a new instance of the CourseController class.
        /// </summary>
        /// <param name="courseService">
        /// Service used for course operations.
        /// </param>
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Creates a new course.
        /// </summary>
        /// <param name="courseDto">
        /// Course information to create.
        /// </param>
        /// <returns>
        /// Returns the created course.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCourse([FromBody] CreateCourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Course data is null."
                });
            }

            var created = await _courseService.CreateCourseAsync(courseDto);

            return StatusCode(StatusCodes.Status201Created, created);
        }

        /// <summary>
        /// Retrieves a course by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the course.
        /// </param>
        /// <returns>
        /// Returns the course if found.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Course with ID {id} not found."
                });
            }

            return Ok(course);
        }

        /// <summary>
        /// Updates an existing course.
        /// </summary>
        /// <param name="id">
        /// The ID of the course to update.
        /// </param>
        /// <param name="courseDto">
        /// Updated course information.
        /// </param>
        /// <returns>
        /// Returns no content if update is successful.
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Course data is null."
                });
            }

            var updated = await _courseService.UpdateCourseAsync(id, courseDto);

            if (!updated)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Course with ID {id} not found."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a course by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the course to delete.
        /// </param>
        /// <returns>
        /// Returns no content if deletion is successful.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _courseService.DeleteCourseAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Course with ID {id} not found."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Retrieves all courses handled by a specific teacher.
        /// </summary>
        /// <param name="teacherId">
        /// The ID of the teacher.
        /// </param>
        /// <returns>
        /// Returns a list of courses for the teacher.
        /// </returns>
        [HttpGet("teacher/{teacherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCoursesByTeacherId(int teacherId)
        {
            var courses = await _courseService.GetCoursesByTeacherIdAsync(teacherId);

            if (courses == null || !courses.Any())
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = "No courses found for this teacher."
                });
            }

            return Ok(courses);
        }

        /// <summary>
        /// Retrieves all courses enrolled by a specific student.
        /// </summary>
        /// <param name="studentId">
        /// The ID of the student.
        /// </param>
        /// <returns>
        /// Returns a list of courses for the student.
        /// </returns>
        [HttpGet("student/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCoursesByStudentId(int studentId)
        {
            var courses = await _courseService.GetCoursesByStudentIdAsync(studentId);

            if (courses == null || !courses.Any())
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = "No courses found for this student."
                });
            }

            return Ok(courses);
        }
    }
}