//using AM_DBTC.Models;
////using System.Net.Http;
////using System.Text.Json;

//namespace AM_DBTC.Services
//{
//    public class AttendanceService : IAttendanceService
//    {
//        private readonly HttpClient _http;

//        public AttendanceService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("ApiClient");
//        }

//        public async Task<AttendanceModel> GetAttendanceAsync(string course, string month)
//        {
//            // to do: replace with real API call when backend is ready
//            // var response = await _http.GetAsync($"/api/attendance?course={course}&month={month}");
//            // response.EnsureSuccessStatusCode();
//            // var json = await response.Content.ReadAsStringAsync();
//            // return JsonSerializer.Deserialize<AttendanceModel>(json) ?? new AttendanceModel();

//            var allRecords = new List<AttendanceRecord>
//            {
//                new() { Date = "3/28", Day = "Sat", Status = "Present", Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                new() { Date = "3/28", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                new() { Date = "3/21", Day = "Sat", Status = "Absent",  Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                new() { Date = "3/21", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                new() { Date = "3/14", Day = "Sat", Status = "Present", Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                new() { Date = "3/14", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                new() { Date = "3/07", Day = "Sat", Status = "Leave",   Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                new() { Date = "3/07", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//            };

//            var filtered = allRecords;

//            if (!string.IsNullOrWhiteSpace(course) && course != "All Courses")
//                filtered = filtered.Where(r => r.Course.Contains(course, StringComparison.OrdinalIgnoreCase)).ToList();

//            return new AttendanceModel
//            {
//                TotalClasses = 30,
//                ClassesPresent = filtered.Count(r => r.Status == "Present"),
//                ClassesAbsent = filtered.Count(r => r.Status == "Absent"),
//                Records = filtered,
//                SelectedCourse = course,
//                SelectedMonth = month,
//                CurrentPage = 1,
//                TotalPages = 1,
//                Courses = new List<string>
//                {
//                    "All Courses",
//                    "Web Applications Development Lab",
//                    "Web Applications Development Lec",
//                    "Information Management",
//                    "Networking Management",
//                    "Phil. History",
//                },
//                Months = new List<string>
//                {
//                    "March 2026",
//                    "February 2026",
//                    "January 2026",
//                },
//            };
//        }
//    }
//}





using AM_DBTC.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AM_DBTC.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly HttpClient _http;
        private const int DefaultPageSize = 5;

        public AttendanceService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }

        // default page size
        public async Task<AttendanceModel> GetAttendanceAsync(string userName, string course, string month, int page = 1, int pageSize = DefaultPageSize)
        {
            var response = await _http.GetAsync($"/api/attendance?course={course}&month={month}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AttendanceModel>(json) ?? new AttendanceModel();
        }
    }
}