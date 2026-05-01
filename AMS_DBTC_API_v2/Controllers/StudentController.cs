using Microsoft.AspNetCore.Mvc;
using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Services.Interface;

namespace AMS_DBTC_API_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {         // POST: api/Student
        private readonly IStudentService _studentService;
        public StudentController(IStudentRepository repo) => _studentService = _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is null.");
            }

            var createdStudent = _studentService.CreateStudentAsync(studentDto).Result;
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, studentDto);
        }
        // GET: api/Student/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            // Logic to retrieve a student record by ID from the database
            // ...
            return Ok(/* student data */);
        }
        // PUT: api/Student/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDTO studentDto)
        {
            // Logic to update an existing student record in the database
            // ...
            return NoContent();
        }
        // DELETE: api/Student/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            // Logic to delete a student record from the database
            // ...
            return NoContent();
        }
    }

}
