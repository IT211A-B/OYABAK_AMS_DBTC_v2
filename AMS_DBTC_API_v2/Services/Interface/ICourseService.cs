using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Services.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO> GetCourseByIdAsync(int id);
        Task<CourseDTO> CreateCourseAsync(CreateCourseDTO courseDto);
        Task<bool> UpdateCourseAsync(int id, UpdateCourseDTO courseDto);
        Task<bool> DeleteCourseAsync(int id);
        Task<IEnumerable<CourseDTO>> GetCoursesByTeacherIdAsync(int teacherId);
        Task<IEnumerable<CourseDTO>> GetCoursesByStudentIdAsync(int studentId);
    }
}
