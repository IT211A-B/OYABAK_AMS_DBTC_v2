using Microsoft.AspNetCore.Mvc;
using AM_DBTC.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AM_DBTC.Services;

namespace AM_DBTC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> CourseView(string search = "", string semester = "All Semesters")
        {
            var model = await _courseService.GetCoursesAsync(search, semester);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Course course)
        {
            await _courseService.AddCourseAsync(course);
            return RedirectToAction("CourseView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {
            await _courseService.EditCourseAsync(course);
            return RedirectToAction("CourseView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string code)
        {
            await _courseService.DeleteCourseAsync(code);
            return RedirectToAction("CourseView");
        }
    }
}





















//namespace AM_DBTC.Controllers
//{
//    public class CourseController : Controller
//    {
//        public IActionResult CourseView(string search = "", string semester = "All Semesters")
//        {
//            var model = BuildModel(search, semester);
//            return View("CourseView", model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Add(Course course)
//        {
//            return RedirectToAction("CourseView", "Course");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Course course)
//        {
//            return RedirectToAction("CourseView", "Course");
//        }



//        private CourseModel BuildModel(string search, string semester)
//        {
//            var allCourses = GetCourses();

//            if (!string.IsNullOrWhiteSpace(search))
//                allCourses = allCourses.Where(c =>
//                    c.Name.Contains(search, System.StringComparison.OrdinalIgnoreCase) || c.Code.Contains(search, System.StringComparison.OrdinalIgnoreCase)).ToList();

//            return new CourseModel
//            {
//                ActiveRoute = "Courses",
//                NavItems = NavHelper.GetNavItems("Courses"),
//                CourseList = allCourses,
//                Semesters = GetSemesters(),
//                SearchTerm = search,
//                SelectedSemester = semester,
//            };
//        }

//        private static List<Course> GetCourses() =>
//        [
//            new() {Code = "GEC 201A", Name = "Readings in Philippine History", Faculty = "Ms. Maria Arianne Diolingo", Semester = "2nd Sem"},
//            new() {Code = "IT 210A", Name = "Information Management", Faculty = "Ms. Joan Maris Rosos", Semester = "2nd Sem"},
//            new() {Code = "IT 211A/B", Name = "Web Applications Development", Faculty = "Ms. Chiara Canque", Semester = "2nd Sem"},
//            new() {Code = "IT 212A/B", Name = "Networking Management", Faculty = "Rev. Fr. Keith J. Amodia, SDB.", Semester = "2nd Sem"},
//        ];

//        private static List<string> GetSemesters() =>
//            ["All Semesters", "1", "2", "Summer"];
//    }
//}