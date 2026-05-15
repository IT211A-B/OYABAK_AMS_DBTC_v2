using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public interface IAttendanceService
    {
        Task<AttendanceModel> GetAttendanceAsync(string userName, string course, string month, int page, int pageSize);
    }
}