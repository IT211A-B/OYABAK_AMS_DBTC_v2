using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS_DBTC_API_v2.Repository.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext _context;

        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
        }

        public async Task<Attendance?> UpdateAsync(Attendance attendance)
        {
            var existing = await _context.Attendances.FindAsync(attendance.AttendanceId);

            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(attendance);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
                return false;

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByCourseIdAsync(int courseId)
        {
            return await _context.Attendances
                .Where(a => a.CourseId == courseId)
                .Include(a => a.Student)
                .Include(a => a.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByStudentIdAsync(int studentId)
        {
            return await _context.Attendances
                .Where(a => a.StudentId == studentId)
                .Include(a => a.Student)
                .Include(a => a.Course)
                .ToListAsync();
        }
    }
}