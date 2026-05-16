using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2.Repository.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int id);

        Task<Attendance> CreateAsync(Attendance attendance);

        Task<Attendance?> UpdateAsync(Attendance attendance);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Attendance>> GetAttendancesByCourseIdAsync(int courseId);
        Task<IEnumerable<Attendance>> GetAttendancesByStudentIdAsync(int studentId);
    }
}