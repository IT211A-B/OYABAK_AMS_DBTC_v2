//using AMS_DBTC_API_v2.DTOs;
//using AMS_DBTC_API_v2.Models;
//using AMS_DBTC_API_v2.Repository;
//using AMS_DBTC_API_v2.Repository.Interface;
//using AMS_DBTC_API_v2.Services.Interface;

//namespace AMS_DBTC_API_v2.Services.Implementations
//{
//    public class StudentService : IStudentService
//    {
//        private readonly IStudentRepository _repo;
//        public IEnumerable<Student> GetStudents()
//        {
//            return _repo.GetAll();
//        }

//        public Student GetStudent(int id)
//        {
//            var student = _repo.GetById(id);

//            if (student == null)
//                throw new Exception("Student not found");

//            return student;
//        }

//        public void DeleteStudent(int id)
//        {
//            var student = _repo.GetById(id);

//            if (student == null)
//                throw new Exception("Student not found");

//            _repo.Delete(student);
//            _repo.Save();
//        }
//    }
//}
