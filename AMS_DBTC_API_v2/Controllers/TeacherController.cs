using Microsoft.AspNetCore.Mvc;
using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Services.Interface;

namespace AMS_DBTC_API_v2.Controllers
{
    /// <summary>
    /// Handles teacher-related operations such as creating,
    /// retrieving, updating, and deleting teacher records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        /// <summary>
        /// Initializes a new instance of the TeacherController class.
        /// </summary>
        /// <param name="teacherService">
        /// Service used for teacher operations.
        /// </param>
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Creates a new teacher record.
        /// </summary>
        /// <param name="teacherDto">
        /// Teacher information to create.
        /// </param>
        /// <returns>
        /// Returns the created teacher record.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTeacher([FromBody] CreateTeacherDTO teacherDto)
        {
            if (teacherDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Teacher data is null."
                });
            }

            var createdTeacher = await _teacherService.CreateTeacherAsync(teacherDto);

            return StatusCode(StatusCodes.Status201Created, createdTeacher);
        }

        /// <summary>
        /// Retrieves a teacher record by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the teacher.
        /// </param>
        /// <returns>
        /// Returns the teacher record if found.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);

            if (teacher == null)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Teacher with ID {id} not found."
                });
            }

            return Ok(teacher);
        }

        /// <summary>
        /// Updates an existing teacher record.
        /// </summary>
        /// <param name="id">
        /// The ID of the teacher to update.
        /// </param>
        /// <param name="teacherDto">
        /// Updated teacher information.
        /// </param>
        /// <returns>
        /// Returns no content if update is successful.
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherDTO teacherDto)
        {
            if (teacherDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Teacher data is null."
                });
            }

            var updated = await _teacherService.UpdateTeacherAsync(id, teacherDto);

            if (!updated)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Teacher with ID {id} not found."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a teacher record by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the teacher to delete.
        /// </param>
        /// <returns>
        /// Returns no content if deletion is successful.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var deleted = await _teacherService.DeleteTeacherAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Teacher with ID {id} not found."
                });
            }

            return NoContent();
        }
    }
}