using AM_DBTC.Models;
using System.Text.Json;

namespace AM_DBTC.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly HttpClient _http;
        private const int DefaultPageSize = 5;

        public FacultyService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }

        public async Task<FacultyModel> GetFacultyAsync(string search, string semester)
        {
            var response = await _http.GetAsync($"/api/faculty?search={search}&semester={semester}");
            response.EnsureSuccessStatusCode();
            var faculty = JsonSerializer.Deserialize<List<Faculty>>(await response.Content.ReadAsStringAsync()) ?? new();
            var model = new FacultyModel {
                Faculties = faculty,
                SearchTerm = search,
                SelectedSemester = semester,
                Semesters= new List<string>()
            };

            return model;
        }

        public async Task AddFacultyAsync(Faculty faculty)
        {
            var response = await _http.PostAsJsonAsync($"/api/faculty", faculty);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditFacultyAsync(Faculty faculty)
        {
            var response = await _http.PutAsJsonAsync($"/api/faculty", faculty);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteFacultyAsync(string empId)
        {
            var response = await _http.DeleteAsync($"/api/faculty/{empId}");
            response.EnsureSuccessStatusCode();
        }
    }
}