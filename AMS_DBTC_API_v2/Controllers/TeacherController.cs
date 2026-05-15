using Microsoft.AspNetCore.Mvc;
using AMS_DBTC_API_v2.Services.Interface;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTeacher([FromBody] CreateTeacherDTO teacherDto)
        {
            if (teacherDto == null)
            {
                return BadRequest("Teacher data is null.");
            }
            var createdTeacher = await _teacherService.CreateTeacherAsync(teacherDto);
            return CreatedAtAction(nameof(GetTeacherById), new { id = createdTeacher.Id }, teacherDto);
        }
        // GET: api/Teacher/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        // PUT: api/Teacher/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherDTO teacherDto)
        {
            var updated = await _teacherService.UpdateTeacherAsync(id, teacherDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        // DELETE: api/Teacher/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var deleted = await _teacherService.DeleteTeacherAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
