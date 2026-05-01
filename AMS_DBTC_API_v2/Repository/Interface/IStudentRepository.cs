using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2.Repository.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);

        Task<Student> AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task<bool> DeleteAsync(Student student);

        
    }
}
