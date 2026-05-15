using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public interface IStudentService
    {
        Task<StudentModel> GetStudentsAsync(string search, string semester, string branch);
        Task AddStudentAsync(Student student);
        Task EditStudentAsync(Student student);
        Task DeleteStudentAsync(string rollNo);
    }
}