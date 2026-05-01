using AMS_DBTC_API_v2.Models;
using AMS_DBTC_API_v2.Repository.Interface;

namespace AMS_DBTC_API_v2.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendanceDbContext _context;
        public StudentRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task<Student> Add(Student student)
        {
            throw new NotImplementedException();
        }
        public async Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task Save()
        {
            throw new NotImplementedException();
        }
        public async Task Update(Student student)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
