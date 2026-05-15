using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public interface ICourseService
    {
        Task<CourseModel> GetCoursesAsync(string search, string semester);
        Task AddCourseAsync(Course course);
        Task EditCourseAsync(Course course);
        Task DeleteCourseAsync(string code);
    }
}