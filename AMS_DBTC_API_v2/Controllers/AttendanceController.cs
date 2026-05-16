using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_API_v2.Controllers
{
    /// <summary>
    /// Handles attendance-related operations such as creating,
    /// retrieving, updating, and deleting attendance records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        /// <summary>
        /// Initializes a new instance of the AttendanceController class.
        /// </summary>
        /// <param name="attendanceService">
        /// Service used for attendance operations.
        /// </param>
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        /// <summary>
        /// Creates a new attendance record.
        /// </summary>
        /// <param name="attendanceDto">
        /// Attendance information to create.
        /// </param>
        /// <returns>
        /// Returns the created attendance record.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAttendance([FromBody] AttendanceUpsertDTO attendanceDto)
        {
            var created = await _attendanceService.CreateAttendanceAsync(attendanceDto);

            if (created == null)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = "Course not found."
                });
            }

            return StatusCode(201, created);
        }

        /// <summary>
        /// Retrieves an attendance record by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the attendance record.
        /// </param>
        /// <returns>
        /// Returns the attendance record if found.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);

            if (attendance == null)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = "Attendance not found."
                });
            }

            return Ok(attendance);
        }

        /// <summary>
        /// Updates an existing attendance record.
        /// </summary>
        /// <param name="id">
        /// The ID of the attendance record to update.
        /// </param>
        /// <param name="attendanceDto">
        /// Updated attendance information.
        /// </param>
        /// <returns>
        /// Returns the updated attendance record.
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAttendance(int id, [FromBody] AttendanceUpsertDTO attendanceDto)
        {
            if (attendanceDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = 400,
                    Message = "Attendance data is null."
                });
            }

            var updated = await _attendanceService.UpdateAttendanceAsync(id, attendanceDto);

            if (updated == null)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Attendance with ID {id} not found."
                });
            }

            return Ok(updated);
        }

        /// <summary>
        /// Deletes an attendance record by ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the attendance record to delete.
        /// </param>
        /// <returns>
        /// Returns no content if deletion is successful.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var deleted = await _attendanceService.DeleteAttendanceAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = $"Attendance with ID {id} not found."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Retrieves all attendance records for a specific course.
        /// </summary>
        /// <param name="courseId">
        /// The ID of the course.
        /// </param>
        /// <returns>
        /// Returns a list of attendance records for the course.
        /// </returns>
        [HttpGet("course/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAttendancesByCourseId(int courseId)
        {
            var attendances = await _attendanceService.GetAttendancesByCourseIdAsync(courseId);

            if (attendances == null || !attendances.Any())
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = "No attendance records found for this course."
                });
            }

            return Ok(attendances);
        }

        /// <summary>
        /// Retrieves all attendance records for a specific student.
        /// </summary>
        /// <param name="studentId">
        /// The ID of the student.
        /// </param>
        /// <returns>
        /// Returns a list of attendance records for the student.
        /// </returns>
        [HttpGet("student/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAttendancesByStudentId(int studentId)
        {
            var attendances = await _attendanceService.GetAttendancesByStudentIdAsync(studentId);

            if (attendances == null || !attendances.Any())
            {
                return NotFound(new ApiResponse
                {
                    StatusCode = 404,
                    Message = "No attendance records found for this student."
                });
            }

            return Ok(attendances);
        }
    }
}