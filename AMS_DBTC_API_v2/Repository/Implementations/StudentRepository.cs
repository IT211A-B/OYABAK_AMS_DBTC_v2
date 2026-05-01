using AMS_DBTC_API_v2.Models;
using AMS_DBTC_API_v2.Repository.Interface;

namespace AMS_DBTC_API_v2.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendanceDbContext _context;
        public StudentRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            await Task.Delay(100); // Simulating async operation
            return _context.Students.ToList();
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await Task.Delay(100); // Simulating async operation
            _context.Students.Add(student);
            return student;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            await Task.Delay(100); // Simulating async operation
            return _context.Students.FirstOrDefault(s => s.StudentId == id);
        }
        public async Task UpdateAsync(Student student)
        {
            await Task.Delay(100); // Simulating async operation
            _context.Students.Update(student);
        }
        public async Task<bool> DeleteAsync(Student student)
        {
            await Task.Delay(100); // Simulating async operation
            _context.Students.Remove(student);
            return true;
        }
    }
}
