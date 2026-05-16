using AM_DBTC.Models;
using System.Text.Json;

namespace AM_DBTC.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _http;
        private const int DefaultPageSize = 5;

        public StudentService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }

        public async Task<StudentModel> GetStudentsAsync(string search, string semester, string branch)
        {
             var response = await _http.GetAsync($"/api/students?search={search}&semester={semester}&branch={branch}");
            response.EnsureSuccessStatusCode();
            var students = JsonSerializer.Deserialize<List<Student>>(await response.Content.ReadAsStringAsync()) ?? new();
            var model = new StudentModel {
                Branches = new List<string>(), // todo get branches
                SearchTerm = search,
                SelectedBranch = branch,
                SelectedSemester = semester,
                Semesters = new List<string>(), // todo get semesters
                Students = students
               };

            return model;
        }

        public async Task AddStudentAsync(Student student)
        {
            var response = await _http.PostAsJsonAsync($"/api/students", student);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditStudentAsync(Student student)
        {
            var response = await _http.PutAsJsonAsync($"/api/students", student);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStudentAsync(string rollNo)
        {
            var response = await _http.DeleteAsync($"/api/students/{rollNo}");
            response.EnsureSuccessStatusCode();
        }
    }
}