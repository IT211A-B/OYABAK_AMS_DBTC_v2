using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository;

namespace AMS_DBTC_API_v2.Services.Interface
{
    public interface IStudentService
    {
       IEnumerable<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int id);
        StudentDTO CreateStudent(CreateStudentDTO studentDto);
        void UpdateStudent(int id, UpdateStudentDTO studentDto);
        void DeleteStudent(int id);
    }
}
