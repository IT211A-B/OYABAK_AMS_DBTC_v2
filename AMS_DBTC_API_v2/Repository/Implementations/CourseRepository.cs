using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace AMS_DBTC_API_v2.Repository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AttendanceDbContext _context;
        public CourseRepository(AttendanceDbContext context)
        {
            _context = context;
        }
        public async Task<Course> CreateAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Teachers)
                .Include(c => c.Students)
                .ToListAsync();
        }
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Teachers)
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }
        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(int teacherId)
        {
            return await _context.Courses.Where(c => c.Teachers.Any(t => t.Id == teacherId)).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(int studentId)
        {
            return await _context.Courses
                .Where(c => c.Students.Any(s => s.StudentId == studentId))
                .ToListAsync();
        }

        public async Task DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}