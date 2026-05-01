using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2.Repository.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);

        Task <Student> Add(Student student);

        Task Update(Student student);

        Task Delete(Student student);

        Task Save();
    }
}
