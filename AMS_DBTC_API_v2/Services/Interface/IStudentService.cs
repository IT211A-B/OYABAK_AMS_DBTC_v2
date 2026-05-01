using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository;

namespace AMS_DBTC_API_v2.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<StudentDTO> CreateStudentAsync(CreateStudentDTO studentDto);
        Task UpdateStudentAsync(int id, UpdateStudentDTO studentDto);
        Task DeleteStudentAsync(int id);
    }
}
