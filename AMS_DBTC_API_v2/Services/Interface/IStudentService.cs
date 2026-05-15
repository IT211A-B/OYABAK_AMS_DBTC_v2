using AMS_DBTC_API_v2.DTOs;

namespace AMS_DBTC_API_v2.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<StudentDTO> CreateStudentAsync(CreateStudentDTO studentDto);
        Task<bool> UpdateStudentAsync(int id, UpdateStudentDTO studentDto);
        Task<bool> DeleteStudentAsync(int id);
    }
}
