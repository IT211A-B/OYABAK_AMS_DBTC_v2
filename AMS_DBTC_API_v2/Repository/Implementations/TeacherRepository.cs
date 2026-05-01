using AMS_DBTC_API_v2.Models;
using AMS_DBTC_API_v2.Repository.Interface;

namespace AMS_DBTC_API_v2.Repository.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AttendanceDbContext _context;
        public TeacherRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            await Task.Delay(100); // Simulating async operation
            return _context.Teachers.ToList();
        }
        public async Task<Teacher> CreateAsync(Teacher teacher)
        {
            await Task.Delay(100); // Simulating async operation
            _context.Teachers.Add(teacher);
            return teacher;
        }
        public async Task<Teacher> GetByIdAsync(int id)
        {
            await Task.Delay(100); // Simulating async operation
            return _context.Teachers.FirstOrDefault(t => t.Id == id);
        }
        public async Task UpdateAsync(Teacher teacher)
        {
            await Task.Delay(100); // Simulating async operation
            _context.Teachers.Update(teacher);
        }
        public async Task<bool> DeleteAsync(Teacher teacher)
        {
            await Task.Delay(100); // Simulating async operation
            _context.Teachers.Remove(teacher);
            return true;
        }
    }
}
