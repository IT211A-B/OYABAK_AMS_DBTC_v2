using AMS_DBTC_API_v2.Services.Interface;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repo;
        public TeacherService(ITeacherRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            var teachers = await _repo.GetAllAsync();
            return teachers.Select(t => new TeacherDTO
            {
                Id = t.Id,
                FirstName = t.FirstName,
                MiddleName = t.MiddleName,
                LastName = t.LastName,
                Email = t.Email,
                Department = t.Department
            });
        }
        public async Task<TeacherDTO> GetTeacherByIdAsync(int id)
        {
            var teacher = await _repo.GetByIdAsync(id);
            if (teacher == null)
                throw new KeyNotFoundException("Teacher not found");
            return new TeacherDTO
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                MiddleName = teacher.MiddleName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                Department = teacher.Department
            };
        }
        public async Task<TeacherDTO> CreateTeacherAsync(CreateTeacherDTO teacherDto)
        {
            var teacher = new Models.Teacher
            {
                FirstName = teacherDto.FirstName,
                MiddleName = teacherDto.MiddleName,
                LastName = teacherDto.LastName,
                Email = teacherDto.Email,
                Department = teacherDto.Department
            };
            var createdTeacher = await _repo.CreateAsync(teacher);
            return new TeacherDTO
            {
                Id = createdTeacher.Id,
                FirstName = createdTeacher.FirstName,
                MiddleName = createdTeacher.MiddleName,
                LastName = createdTeacher.LastName,
                Email = createdTeacher.Email,
                Department = createdTeacher.Department
            };
        }
        public async Task UpdateTeacherAsync(int id, UpdateTeacherDTO teacherDto)
        {
            var existingTeacher = await _repo.GetByIdAsync(id);
            if (existingTeacher == null)
                throw new KeyNotFoundException("Teacher not found");
            existingTeacher.FirstName = teacherDto.FirstName;
            existingTeacher.MiddleName = teacherDto.MiddleName;
            existingTeacher.LastName = teacherDto.LastName;
            existingTeacher.Email = teacherDto.Email;
            existingTeacher.Department = teacherDto.Department;
            await _repo.UpdateAsync(existingTeacher);
        }
        public async Task DeleteTeacherAsync(int id)
        {
            var existingTeacher = await _repo.GetByIdAsync(id);
            if (existingTeacher == null)
                throw new KeyNotFoundException("Teacher not found");
            await _repo.DeleteAsync(existingTeacher);
        }
    }
}
