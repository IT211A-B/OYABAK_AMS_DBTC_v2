using Microsoft.AspNetCore.Mvc;
using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Services.Interface;

namespace AMS_DBTC_API_v2.Controllers
{
    /// <summary>
    /// Handles student-related operations such as creating,
    /// retrieving, updating, and deleting student records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the StudentController class.
        /// </summary>
        /// <param name="studentService">
        /// Service used for student operations.
        /// </param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Retrieves all student records.
        /// </summary>
        /// <returns>
        /// Returns a list of all students.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        /// <summary>
        /// Creates a new student record.
        /// </summary>
        /// <param name="studentDto">
        /// Student information to create.
        /// </param>
        /// <returns>
        /// Returns the created student record.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Student data is null."
                });
            }

            var createdStudent = await _studentService.CreateStudentAsync(studentDto);

            return StatusCode(StatusCodes.Status201Created, createdStudent);
        }

        /// <summary>
        /// Retrieves a student record by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the student.
        /// </param>
        /// <returns>
        /// Returns the student record if found.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Student with ID {id} not found."
                });
            }

            return Ok(student);
        }

        /// <summary>
        /// Updates an existing student record.
        /// </summary>
        /// <param name="id">
        /// The ID of the student to update.
        /// </param>
        /// <param name="studentDto">
        /// Updated student information.
        /// </param>
        /// <returns>
        /// Returns no content if update is successful.
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Student data is null."
                });
            }

            var updated = await _studentService.UpdateStudentAsync(id, studentDto);

            if (!updated)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Student with ID {id} not found."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a student record by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the student to delete.
        /// </param>
        /// <returns>
        /// Returns no content if deletion is successful.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Student with ID {id} not found."
                });
            }

            return NoContent();
        }
    }
}