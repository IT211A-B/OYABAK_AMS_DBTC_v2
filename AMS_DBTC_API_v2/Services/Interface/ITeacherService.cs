using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Services.Interface
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<TeacherDTO> GetTeacherByIdAsync(int id);
        Task<TeacherDTO> CreateTeacherAsync(CreateTeacherDTO teacherDto);
        Task<bool> UpdateTeacherAsync(int id, UpdateTeacherDTO teacherDto);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
