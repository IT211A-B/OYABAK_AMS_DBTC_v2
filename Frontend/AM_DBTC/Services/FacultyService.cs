//using AM_DBTC.Models;
////using System.Text;
////using System.Text.Json;

//namespace AM_DBTC.Services
//{
//    public class FacultyService : IFacultyService
//    {
//        private readonly HttpClient _http;

//        public FacultyService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("ApiClient");
//        }

//        public async Task<FacultyModel> GetFacultyAsync(string search, string semester)
//        {
//            // to do: replace with real API call when backend is ready
//            // var response = await _http.GetAsync($"/api/faculty?search={search}&semester={semester}");
//            // response.EnsureSuccessStatusCode();
//            // var faculty = JsonSerializer.Deserialize<List<Faculty>>(await response.Content.ReadAsStringAsync()) ?? new();

//            var faculty = new List<Faculty>
//            {
//                new() { EmpId = "001", Name = "Ms. Maria Arianne Diolingo",    Department = "College", Courses = 2 },
//                new() { EmpId = "002", Name = "Ms. Joan Maris Rosos",          Department = "College", Courses = 2 },
//                new() { EmpId = "003", Name = "Ms. Chiara Canque",             Department = "College", Courses = 2 },
//                new() { EmpId = "004", Name = "Rev. Fr. Keith J. Amodia, SDB.", Department = "College", Courses = 2 },
//            };

//            if (!string.IsNullOrWhiteSpace(search))
//                faculty = faculty.Where(f =>
//                    f.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
//                    f.EmpId.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

//            return new FacultyModel
//            {
//                Faculties = faculty,
//                SearchTerm = search,
//                SelectedSemester = semester,
//                Semesters = new List<string> { "All Semesters", "1", "2", "Summer" },
//            };
//        }

//        public async Task AddFacultyAsync(Faculty faculty)
//        {
//            // to do: replace with real API call
//            await Task.CompletedTask;
//        }

//        public async Task EditFacultyAsync(Faculty faculty)
//        {
//            // to do: replace with real API call
//            await Task.CompletedTask;
//        }

//        public async Task DeleteFacultyAsync(string empId)
//        {
//            // to do: replace with real API call
//            await Task.CompletedTask;
//        }
//    }
//}














using AM_DBTC.Models;

namespace AM_DBTC.Services
{
    public class FacultyService : IFacultyService
    {
        public Task<FacultyModel> GetFacultyAsync(string search, string semester)
        {
            // to do: replace with real API call when backend is ready
            // var response = await _http.GetAsync($"/api/faculty?search={search}&semester={semester}");
            // response.EnsureSuccessStatusCode();
            // var faculty = JsonSerializer.Deserialize<List<Faculty>>(await response.Content.ReadAsStringAsync()) ?? new();

            var faculty = new List<Faculty>
            {
                new() { EmpId = "001", Name = "Ms. Maria Arianne Diolingo",     Department = "College", Courses = 2 },
                new() { EmpId = "002", Name = "Ms. Joan Maris Rosos",           Department = "College", Courses = 2 },
                new() { EmpId = "003", Name = "Ms. Chiara Canque",              Department = "College", Courses = 2 },
                new() { EmpId = "004", Name = "Rev. Fr. Keith J. Amodia, SDB.", Department = "College", Courses = 2 },
            };

            if (!string.IsNullOrWhiteSpace(search))
                faculty = faculty.Where(f =>
                    f.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    f.EmpId.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            var model = new FacultyModel
            {
                Faculties = faculty,
                SearchTerm = search,
                SelectedSemester = semester,
                Semesters = new List<string> { "All Semesters", "1", "2", "Summer" },
            };

            return Task.FromResult(model);
        }

        public Task AddFacultyAsync(Faculty faculty)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }

        public Task EditFacultyAsync(Faculty faculty)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }

        public Task DeleteFacultyAsync(string empId)
        {
            // to do: replace with real API call
            return Task.CompletedTask;
        }
    }
}