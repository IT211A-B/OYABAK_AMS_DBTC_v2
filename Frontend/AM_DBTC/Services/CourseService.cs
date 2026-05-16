using AM_DBTC.Models;
using System.Text.Json;

namespace AM_DBTC.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _http;
        private const int DefaultPageSize = 5;

        public CourseService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }

        public async Task<CourseModel> GetCoursesAsync(string search, string semester)
        {
            // to do: replace with real API call when backend is ready
             var response = await _http.GetAsync($"/api/courses?search={search}&semester={semester}");
            response.EnsureSuccessStatusCode();
            var courses = JsonSerializer.Deserialize<List<Course>>(await response.Content.ReadAsStringAsync()) ?? new();

            var model = new CourseModel
            {
                Courses = courses,
                SearchTerm = search,
                SelectedSemester = semester,
                Semesters = new List<string> { "All Semesters", "1st Sem", "2nd Sem", "Summer" },
            };

            return model;
        }

        public async Task AddCourseAsync(Course course)
        {
            var response = await _http.PostAsJsonAsync($"/api/courses", course);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditCourseAsync(Course course)
        {
            var response = await _http.PutAsJsonAsync($"/api/courses", course);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCourseAsync(string code)
        {
            var response = await _http.DeleteAsync($"/api/courses/{code}");
            response.EnsureSuccessStatusCode();
        }
    }
}