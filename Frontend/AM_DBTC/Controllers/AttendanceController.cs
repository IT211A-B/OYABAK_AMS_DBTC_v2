using Microsoft.AspNetCore.Mvc;
using AM_DBTC.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AM_DBTC.Services;


namespace AM_DBTC.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public async Task<IActionResult> AttendanceView(string course = "", string month = "March 2026")
        {
            var model = await _attendanceService.GetAttendanceAsync(course, month);
            return View("AttendanceView", model);
        }
    }
}













































//namespace AM_DBTC.Controllers
//{
//    public class AttendanceController : Controller
//    {
//        public IActionResult Index()
//        {
//            var model = BuildAttendanceModel(course, month);
//            return View("StudentMyAttendanceView", model);
//        }

//        private AttendanceModel BuildAttendanceModel(string course, string month)
//        {
//            return new AttendanceModel
//            {
//                ActiveRoute = "Attendance",
//                User = GetStudentUser(),
//                NavItems = GetNavItems("Attendance"),
//                TotalClasses = 30,
//                ClassesPresent = 20,
//                ClassesAbsent = 2,
//                SelectedCourse = course,
//                SelectedMonth = month,
//                CurrentPage = 1,
//                TotalPages = 1,
//                Courses = new List<string>
//                {
//                    "Web Applications...",
//                    "Information Management",
//                    "Networking Management",
//                    "Phil. History",
//                },

//                Months = new List<string>
//                {
//                    "March 2026", "February 2026", "January 2026",
//                },

//                Records = new List<AttendanceRecord>
//                {
//                    new() { Date = "3/28", Day = "Sat", Status = "Present", Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                    new() { Date = "3/28", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                    new() { Date = "3/21", Day = "Sat", Status = "Absent",  Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                    new() { Date = "3/21", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                    new() { Date = "3/14", Day = "Sat", Status = "Present", Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                    new() { Date = "3/14", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                    new() { Date = "3/07", Day = "Sat", Status = "Leave",   Time = "10:00 AM", Course = "Web Applications Development Lab" },
//                    new() { Date = "3/07", Day = "Sat", Status = "Present", Time = "8:00 AM",  Course = "Web Applications Development Lec" },
//                },
//            };
//        }

//        private static StudentUser GetStudentUser() => new()
//        {
//            Name = "KIERSTIEN SERVAN VERANO",
//            Role = "Student",
//        };

//        private static List<StudentNavItem> GetNavItems(string activeRoute) =>
//        [
//            new() { Label = "Dashboard", IconKey = "grid", Controller = "StudentDashboard", Action = "StudentDashboardView", IsActive = activeRoute == "StudentDashboard" },
//            new() { Label = "My Attendance", IconKey = "calendar", Controller = "StudentMyAttendance", Action = "StudentMyAttendanceView", IsActive = activeRoute == "StudentMyAttendance" },
//            new() { Label = "My Courses", IconKey = "book", Controller = "StudentDashboard", Action = "StudentDashboardView", IsActive = activeRoute == "StudentCourses" },
//            new() { Label = "Alerts", IconKey = "alert", Controller = "StudentDashboard", Action = "StudentDashboardView", IsActive = activeRoute == "StudentAlerts" },
//            new() { Label = "Settings", IconKey = "settings", Controller = "StudentDashboard", Action = "StudentDashboardView", IsActive = activeRoute == "StudentSettings" },
//        ];
//    }
//}