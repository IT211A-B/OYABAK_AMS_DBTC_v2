using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2.Repository.Interface
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task<bool> DeleteAsync(Teacher teacher);
    }
}
