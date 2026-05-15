//using AM_DBTC.Models;
////using System.Text;
////using System.Text.Json;

//namespace AM_DBTC.Services
//{
//    public class CourseService : ICourseService
//    {
//        private readonly HttpClient _http;

//        public CourseService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("ApiClient");
//        }

//        public async Task<CourseModel> GetCoursesAsync(string search, string semester)
//        {
//            // to do: replace with real API call when backend is ready
//            // var response = await _http.GetAsync($"/api/courses?search={search}&semester={semester}");
//            // response.EnsureSuccessStatusCode();
//            // var courses = JsonSerializer.Deserialize<List<Course>>(await response.Content.ReadAsStringAsync()) ?? new();

//            var courses = new List<Course>
//            {
//                new() { Code = "GEC 201A",  Name = "Readings in Philippine History", Faculty = "Ms. Maria Arianne Diolingo",     Semester = "2nd Sem" },
//                new() { Code = "IT 210A",   Name = "Information Management",         Faculty = "Ms. Joan Maris Rosos",           Semester = "2nd Sem" },
//                new() { Code = "IT 211A/B", Name = "Web Applications Development",   Faculty = "Ms. Chiara Canque",              Semester = "2nd Sem" },
//                new() { Code = "IT 212A/B", Name = "Networking Management",          Faculty = "Rev. Fr. Keith J. Amodia, SDB.", Semester = "2nd Sem" },
//            };

//            if (!string.IsNullOrWhiteSpace(search))
//                courses = courses.Where(c =>
//                    c.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
//                    c.Code.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

//            if (semester != "All Semesters")
//                courses = courses.Where(c => c.Semester.Contains(semester, StringComparison.OrdinalIgnoreCase)).ToList();

//            return new CourseModel
//            {
//                Courses       = courses,
//                SearchTerm       = search,
//                SelectedSemester = semester,
//                Semesters        = new List<string> { "All Semesters", "1st Sem", "2nd Sem", "Summer" },
//            };
//        }

//        public async Task AddCourseAsync(Course course)
//        {
//            // to do: replace with real API call
//            await Task.CompletedTask;
//        }

//        public async Task EditCourseAsync(Course course)
//        {
//            // to do: replace with real API call
//            await Task.CompletedTask;
//        }

//        public async Task DeleteCourseAsync(string code)
//        {
//            // to do: replace with real API call
//            await Task.CompletedTask;
//        }
//    }
//}













using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public class CourseService : ICourseService
    {
        public Task<CourseModel> GetCoursesAsync(string search, string semester)
        {
            // to do: replace with real API call when backend is ready
            // var response = await _http.GetAsync($"/api/courses?search={search}&semester={semester}");
            // response.EnsureSuccessStatusCode();
            // var courses = JsonSerializer.Deserialize<List<Course>>(await response.Content.ReadAsStringAsync()) ?? new();

            var courses = new List<Course>
            {
                new() { Code = "GEC 201A",  Name = "Readings in Philippine History", Faculty = "Ms. Maria Arianne Diolingo",     Semester = "2nd Sem" },
                new() { Code = "IT 210A",   Name = "Information Management",         Faculty = "Ms. Joan Maris Rosos",           Semester = "2nd Sem" },
                new() { Code = "IT 211A/B", Name = "Web Applications Development",   Faculty = "Ms. Chiara Canque",              Semester = "2nd Sem" },
                new() { Code = "IT 212A/B", Name = "Networking Management",          Faculty = "Rev. Fr. Keith J. Amodia, SDB.", Semester = "2nd Sem" },
            };

            if (!string.IsNullOrWhiteSpace(search))
                courses = courses.Where(c =>
                    c.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    c.Code.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            if (semester != "All Semesters")
                courses = courses.Where(c => c.Semester.Contains(semester, StringComparison.OrdinalIgnoreCase)).ToList();

            var model = new CourseModel
            {
                Courses = courses,
                SearchTerm = search,
                SelectedSemester = semester,
                Semesters = new List<string> { "All Semesters", "1st Sem", "2nd Sem", "Summer" },
            };

            return Task.FromResult(model);
        }

        public Task AddCourseAsync(Course course)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }

        public Task EditCourseAsync(Course course)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }

        public Task DeleteCourseAsync(string code)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }
    }
}