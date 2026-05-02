using AMS_DBTC_API_v2.Services.Interface;
using AMS_DBTC_API_v2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_API_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance([FromBody] AttendanceUpsertDTO attendanceDto)
        {
            if (attendanceDto == null)
                return BadRequest("Attendance data is null.");

            var created = await _attendanceService.CreateAttendanceAsync(attendanceDto);

            return CreatedAtAction(nameof(GetAttendanceById),
                new { id = created.AttendanceId },
                created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);

            if (attendance == null)
                return NotFound();

            return Ok(attendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, [FromBody] AttendanceUpsertDTO attendanceDto)
        {
            if (attendanceDto == null)
                return BadRequest("Attendance data is null.");

            var updated = await _attendanceService.UpdateAttendanceAsync(id, attendanceDto);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);
            return NoContent();
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetAttendancesByCourseId(int courseId)
        {
            var attendances = await _attendanceService.GetAttendancesByCourseIdAsync(courseId);
            return Ok(attendances);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetAttendancesByStudentId(int studentId)
        {
            var attendances = await _attendanceService.GetAttendancesByStudentIdAsync(studentId);
            return Ok(attendances);
        }
    }
}