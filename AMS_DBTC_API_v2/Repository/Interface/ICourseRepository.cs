using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);
        Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(int teacherId);
        Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(int studentId);
    }
}
