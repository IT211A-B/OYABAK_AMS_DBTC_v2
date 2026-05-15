using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public interface IAttendanceService
    {
        Task<AttendanceModel> GetAttendanceAsync(string course, string month);
    }
}