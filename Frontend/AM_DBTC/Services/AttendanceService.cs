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
        // default page size
        private const int DefaultPageSize = 5;
        public Task<AttendanceModel> GetAttendanceAsync(string userName, string course, string month, int page = 1, int pageSize = DefaultPageSize)
        {
            // to do: replace with real API call when backend is ready
            // var response = await _http.GetAsync($"/api/attendance?course={course}&month={month}");
            // response.EnsureSuccessStatusCode();
            // var json = await response.Content.ReadAsStringAsync();
            // return JsonSerializer.Deserialize<AttendanceModel>(json) ?? new AttendanceModel();


            // example guide:

//            public class AttendanceService : IAttendanceService
//        {
//            private readonly HttpClient _http;

//            public AttendanceService(IHttpClientFactory factory)
//            {
//                _http = factory.CreateClient("ApiClient");
//            }

//            public async Task<AttendanceModel> GetAttendanceAsync(string userName, string course, string month, int page = 1, int pageSize = 10)
//            {
//                // Build query parameters
//                var query = new List<string>();
//                if (!string.IsNullOrWhiteSpace(userName))
//                    query.Add($"userName={Uri.EscapeDataString(userName)}");
//                if (!string.IsNullOrWhiteSpace(course) && course != "All Courses")
//                    query.Add($"course={Uri.EscapeDataString(course)}");
//                if (!string.IsNullOrWhiteSpace(month) && month != "All Dates")
//                    query.Add($"month={Uri.EscapeDataString(month)}");
//                query.Add($"page={page}");
//                query.Add($"pageSize={pageSize}");

//                var url = "/api/attendance";
//                if (query.Count > 0)
//                    url += "?" + string.Join("&", query);

//                // Call the backend API
//                var response = await _http.GetAsync(url);
//                response.EnsureSuccessStatusCode(); // throws if not 2xx

//                var json = await response.Content.ReadAsStringAsync();

//                // Deserialize JSON into AttendanceModel
//                var model = JsonSerializer.Deserialize<AttendanceModel>(json, new JsonSerializerOptions
//                {
//                    PropertyNameCaseInsensitive = true
//                }) ?? new AttendanceModel();

//                return model;
//            }
//        }
//}

            var allRecords = new List<AttendanceRecord>
            {
                new() { UserName = "Oyabak Oyabak", Date = new DateTime(2026, 3, 28), Day = "Sat", Status = "Present", Time = "10:00 AM", Course = "Web Applications Development Lab" },
                new() { UserName = "Oyabak Oyabak", Date = new DateTime(2026, 3, 28), Day = "Sat", Status = "Present", Time = "8:00 AM", Course = "Web Applications Development Lec" },
                new() { UserName = "Bryan Empes Quino", Date = new DateTime(2026, 2, 21), Day = "Sat", Status = "Absent", Time = "10:00 AM", Course = "Web Applications Development Lab" },
                new() { UserName = "Bryan Empes Quino", Date = new DateTime(2026, 2, 21), Day = "Sat", Status = "Present", Time = "8:00 AM", Course = "Web Applications Development Lec" },
                new() { UserName = "Kierstien Servan Verano", Date = new DateTime(2026, 1, 14), Day = "Sat", Status = "Present", Time = "10:00 AM", Course = "Web Applications Development Lab" },
                new() { UserName = "Leachim Cabingatan Dela Cerna", Date = new DateTime(2026, 3, 7), Day = "Sat", Status = "Leave", Time = "10:00 AM", Course = "Web Applications Development Lab" }
            };

            var filtered = allRecords;

            // user filter
            if (!string.IsNullOrWhiteSpace(userName))
            {
                filtered = filtered.Where(r => r.UserName.Contains(userName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // course filter
            if (!string.IsNullOrWhiteSpace(course) && course != "All Courses")
            {
                filtered = filtered.Where(r => r.Course == course).ToList();
            }

            // month filter
            if (!string.IsNullOrWhiteSpace(month) && month != "All Dates")
            {
                //month names to month numbers
                var monthNumber = month switch
                {
                    "January" => 1,
                    "February" => 2,
                    "March" => 3,
                    "April" => 4,
                    "May" => 5,
                    "June" => 6,
                    "July" => 7,
                    "August" => 8,
                    "September" => 9,
                    "October" => 10,
                    "November" => 11,
                    "December" => 12,
                    _ => 0
                };

                if (monthNumber > 0)
                {
                    filtered = filtered.Where(r => r.Date.Month == monthNumber).ToList();
                }
            }

            // sort by date desc (latest first)
            filtered = filtered.OrderByDescending(r => r.Date).ToList();

            // pagination
            var totalRecords = filtered.Count;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            // take only current page records
            var pagedRecords = filtered.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Task.FromResult(new AttendanceModel
            {
                Records = pagedRecords,
                CurrentPage = page,
                TotalPages = totalPages,
                SelectedCourse = course,
                SelectedMonth = month,
                TotalClasses = 30,
                ClassesPresent = filtered.Count(r => r.Status == "Present"),
                ClassesAbsent = filtered.Count(r => r.Status == "Absent"),

                Courses = new List<string>
                {
                    "All Courses",
                    "Web Applications Development Lab",
                    "Web Applications Development Lec",
                    "Information Management",
                    "Networking Management",
                    "Phil. History",
                },

                Months = new List<string>
                {
                    "All Dates",
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December",
                },
            });

        }
    }
}