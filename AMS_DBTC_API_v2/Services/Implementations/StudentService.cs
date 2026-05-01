using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Services.Interface;
using AMS_DBTC_API_v2.Enums;

namespace AMS_DBTC_API_v2.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _repo.GetAllAsync();
            return students.Select(s => new StudentDTO
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                RollNumber = s.RollNumber,
                Email = s.Email,
                YearLevel = (YearLevel)s.yearLevel,
                sex = (Sex)s.sex,
            });
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
                throw new Exception("Student not found");

            return new StudentDTO
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                RollNumber = student.RollNumber,
                Email = student.Email,
                YearLevel = (YearLevel)student.yearLevel,
                sex = (Sex)student.sex
            };
        }
        public async Task<StudentDTO> CreateStudentAsync(CreateStudentDTO studentDto)
        {
            var student = new Models.Student
            {
                FirstName = studentDto.FirstName,
                MiddleName = studentDto.MiddleName,
                LastName = studentDto.LastName,
                RollNumber = studentDto.RollNumber,
                Email = studentDto.Email,
                yearLevel = (YearLevel)studentDto.yearLevel,
                sex = (Sex)studentDto.sex
            };

            var createdStudent = await _repo.AddAsync(student);
            return new StudentDTO
            {
                StudentId = createdStudent.StudentId,
                FirstName = createdStudent.FirstName,
                MiddleName = createdStudent.MiddleName,
                LastName = createdStudent.LastName,
                RollNumber = createdStudent.RollNumber,
                Email = createdStudent.Email,
                YearLevel = (YearLevel)createdStudent.yearLevel,
                sex = (Sex)createdStudent.sex
            };
        }
        public async Task UpdateStudentAsync(int id, UpdateStudentDTO studentDto)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student == null)
                throw new Exception("Student not found");
            student.FirstName = studentDto.FirstName;
            student.MiddleName = studentDto.MiddleName;
            student.LastName = studentDto.LastName;
            student.RollNumber = studentDto.RollNumber;
            student.Email = studentDto.Email;
            student.yearLevel = (YearLevel)studentDto.yearLevel;
            student.sex = (Sex)studentDto.sex;

            await _repo.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _repo.GetByIdAsync (id);

            if (student == null)
                throw new Exception("Student not found");

            var result = await _repo.DeleteAsync(student);
            if (!result)
                throw new Exception("Failed to delete student");
        }
    }
}
