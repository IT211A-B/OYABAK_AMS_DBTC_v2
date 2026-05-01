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
        public TeacherController(ITeacherRepository repo) => _teacherService = _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpPost]
        public IActionResult AddTeacher([FromBody] CreateTeacherDTO teacherDto)
        {
            if (teacherDto == null)
            {
                return BadRequest("Teacher data is null.");
            }
            var createdTeacher = _teacherService.CreateTeacherAsync(teacherDto).Result;
            return CreatedAtAction(nameof(GetTeacherById), new { id = createdTeacher.Id }, teacherDto);
        }
        // GET: api/Teacher/{id}
        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            // Logic to retrieve a teacher record by ID from the database
            // ...
            return Ok(/* teacher data */);
        }
        // PUT: api/Teacher/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] UpdateTeacherDTO teacherDto)
        {
            // Logic to update an existing teacher record in the database
            // ...
            return NoContent();
        }
        // DELETE: api/Teacher/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            // Logic to delete a teacher record from the database
            // ...
            return NoContent();
        }
    }
}
