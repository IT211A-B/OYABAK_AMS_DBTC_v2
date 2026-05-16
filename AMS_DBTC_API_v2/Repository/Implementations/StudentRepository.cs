using AMS_DBTC_API_v2.Models;
using AMS_DBTC_API_v2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync(); 
            return student;
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync(); 
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync(); 
            return true;
        }
    }
}