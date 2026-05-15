using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public interface IFacultyService
    {
        Task<FacultyModel> GetFacultyAsync(string search, string semester);
        Task AddFacultyAsync(Faculty faculty);
        Task EditFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(string empId);
    }
}