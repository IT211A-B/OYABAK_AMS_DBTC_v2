using AMS_DBTC_API_v2.Models;
using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Repository.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int id);
        Task<Attendance> CreateAsync(Attendance attendance);
        Task<Attendance> UpdateAsync(Attendance attendance);
        Task DeleteAsync(int id);
        Task<IEnumerable<Attendance>> GetAttendancesByCourseIdAsync(int courseId);
        Task<IEnumerable<Attendance>> GetAttendancesByStudentIdAsync(int studentId);
    }
}
