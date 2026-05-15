//using AM_DBTC.Models;
////using System.Text;
////using System.Text.Json;

//namespace AM_DBTC.Services
//{
//    public class StudentService : IStudentService
//    {
//        private readonly HttpClient _http;

//        public StudentService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("ApiClient");
//        }

//        public async Task<StudentModel> GetStudentsAsync(string search, string semester, string branch)
//        {
//            // to do: replace with real API call when backend is ready
//            // var response = await _http.GetAsync($"/api/students?search={search}&semester={semester}&branch={branch}");
//            // response.EnsureSuccessStatusCode();
//            // var students = JsonSerializer.Deserialize<List<Student>>(await response.Content.ReadAsStringAsync()) ?? new();

//            var students = new List<Student>
//            {
//                new() { RollNo = "24060176", Name = "Oyabak Oyabak",                Semester = 2, Course = "BSIT" },
//                new() { RollNo = "24060177", Name = "Leachim Cabingatan Dela Cerna", Semester = 2, Course = "BSIT" },
//                new() { RollNo = "24060178", Name = "Bryan Empes Quino",             Semester = 2, Course = "BSIT" },
//                new() { RollNo = "24060179", Name = "Kierstien Servan Verano",       Semester = 2, Course = "BSIT" },
//            };

//            if (!string.IsNullOrWhiteSpace(search))
//                students = students.Where(s =>
//                    s.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
//                    s.RollNo.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

//            if (semester != "All Semesters")
//                students = students.Where(s => s.Semester.ToString() == semester).ToList();

//            if (branch != "All Branches")
//                students = students.Where(s => s.Course == branch).ToList();

//            return new StudentModel
//            {
//                Students = students,
//                SearchTerm = search,
//                SelectedSemester = semester,
//                SelectedBranch = branch,
//                Semesters = new List<string> { "All Semesters", "1", "2", "Summer" },
//                Branches = new List<string> { "All Branches", "BSIT", "BSME", "TVET" },
//            };
//        }

//        public async Task AddStudentAsync(Student student)
//        {
//            // to do: replace with real API call
//            // var json    = JsonSerializer.Serialize(student);
//            // var content = new StringContent(json, Encoding.UTF8, "application/json");
//            // var response = await _http.PostAsync("/api/students", content);
//            // response.EnsureSuccessStatusCode();
//            await Task.CompletedTask;
//        }

//        public async Task EditStudentAsync(Student student)
//        {
//            // to do: replace with real API call
//            // var json    = JsonSerializer.Serialize(student);
//            // var content = new StringContent(json, Encoding.UTF8, "application/json");
//            // var response = await _http.PutAsync($"/api/students/{student.RollNo}", content);
//            // response.EnsureSuccessStatusCode();
//            await Task.CompletedTask;
//        }

//        public async Task DeleteStudentAsync(string rollNo)
//        {
//            // to do: replace with real API call
//            // var response = await _http.DeleteAsync($"/api/students/{rollNo}");
//            // response.EnsureSuccessStatusCode();
//            await Task.CompletedTask;
//        }
//    }
//}













using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public class StudentService : IStudentService
    {
        public Task<StudentModel> GetStudentsAsync(string search, string semester, string branch)
        {
            // to do: replace with real API call when backend is ready
            // var response = await _http.GetAsync($"/api/students?search={search}&semester={semester}&branch={branch}");
            // response.EnsureSuccessStatusCode();
            // var students = JsonSerializer.Deserialize<List<Student>>(await response.Content.ReadAsStringAsync()) ?? new();

            var students = new List<Student>
            {
                new() { RollNo = "24060176", Name = "Oyabak Oyabak",                Semester = 2, Course = "BSIT" },
                new() { RollNo = "24060177", Name = "Leachim Cabingatan Dela Cerna", Semester = 2, Course = "BSIT" },
                new() { RollNo = "24060178", Name = "Bryan Empes Quino",             Semester = 2, Course = "BSIT" },
                new() { RollNo = "24060179", Name = "Kierstien Servan Verano",       Semester = 2, Course = "BSIT" },
            };

            if (!string.IsNullOrWhiteSpace(search))
                students = students.Where(s =>
                    s.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    s.RollNo.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            if (semester != "All Semesters")
                students = students.Where(s => s.Semester.ToString() == semester).ToList();

            if (branch != "All Branches")
                students = students.Where(s => s.Course == branch).ToList();

            var model = new StudentModel
            {
                Students = students,
                SearchTerm = search,
                SelectedSemester = semester,
                SelectedBranch = branch,
                Semesters = new List<string> { "All Semesters", "1", "2", "Summer" },
                Branches = new List<string> { "All Branches", "BSIT", "BSME", "TVET" },
            };

            return Task.FromResult(model);
        }

        public Task AddStudentAsync(Student student)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }

        public Task EditStudentAsync(Student student)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }

        public Task DeleteStudentAsync(string rollNo)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }
    }
}