using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Services.Interface
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetAllAsync();
        Task<AttendanceDTO> GetAttendanceByIdAsync(int id);
        Task<AttendanceDTO> CreateAttendanceAsync(AttendanceUpsertDTO attendanceDto);
        Task<bool> UpdateAttendanceAsync(int id, AttendanceUpsertDTO attendanceDto);
        Task<bool> DeleteAttendanceAsync(int id);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByCourseIdAsync(int courseId);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId);
    }
}
