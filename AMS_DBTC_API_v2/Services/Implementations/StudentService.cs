using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Services.Interface;

namespace AMS_DBTC_API_v2.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

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
                YearLevel = s.yearLevel,
                sex = s.sex,
            });
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
                return null;

            return new StudentDTO
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                RollNumber = student.RollNumber,
                Email = student.Email,
                YearLevel = student.yearLevel,
                sex = student.sex,
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
                yearLevel = studentDto.yearLevel,
                sex = studentDto.sex,
                Program = studentDto.Program,
                CourseId = studentDto.CourseId
            };

            var createdStudent = await _repo.CreateAsync(student);

            return new StudentDTO
            {
                StudentId = createdStudent.StudentId,
                FirstName = createdStudent.FirstName,
                MiddleName = createdStudent.MiddleName,
                LastName = createdStudent.LastName,
                RollNumber = createdStudent.RollNumber,
                Email = createdStudent.Email,
                YearLevel = createdStudent.yearLevel,
                sex = createdStudent.sex,
            };
        }

        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDTO studentDto)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
                return false;

            student.FirstName = studentDto.FirstName;
            student.MiddleName = studentDto.MiddleName;
            student.LastName = studentDto.LastName;
            student.RollNumber = studentDto.RollNumber;
            student.Email = studentDto.Email;
            student.yearLevel = studentDto.yearLevel;
            student.sex = studentDto.sex;

            await _repo.UpdateAsync(student);

            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
                return false;

            var result = await _repo.DeleteAsync(student);

            if (!result)
                return false;

            return true;
        }
    }
}