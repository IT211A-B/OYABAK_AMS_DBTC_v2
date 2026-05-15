using Microsoft.AspNetCore.Mvc;
using AM_DBTC.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AM_DBTC.Services;

namespace AM_DBTC.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        public async Task<IActionResult> FacultyView(string search = "", string semester = "All Semesters")
        {
            var model = await _facultyService.GetFacultyAsync(search, semester);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Faculty faculty)
        {
            await _facultyService.AddFacultyAsync(faculty);
            return RedirectToAction("FacultyView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Faculty faculty)
        {
            await _facultyService.EditFacultyAsync(faculty);
            return RedirectToAction("FacultyView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string empId)
        {
            await _facultyService.DeleteFacultyAsync(empId);
            return RedirectToAction("FacultyView");
        }
    }
}





















//namespace AM_DBTC.Controllers
//{
//    public class FacultyController : Controller
//    {
//        public IActionResult FacultyView(string search = "", string semester = "All Semesters")
//        {
//            var model = BuildModel(search, semester);
//            return View("FacultyView", model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Add(Faculty faculty)
//        {
//            return RedirectToAction("FacultyView", "Faculty");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Faculty faculty)
//        {
//            return RedirectToAction("FacultyView", "Faculty");
//        }

//        private FacultyModel BuildModel(string search, string semester)
//        {
//            var allFaculty = GetFaculty();

//            if (!string.IsNullOrWhiteSpace(search))
//                allFaculty = allFaculty.Where(f =>
//                    f.Name.Contains(search, System.StringComparison.OrdinalIgnoreCase) || f.EmpId.Contains(search, System.StringComparison.OrdinalIgnoreCase)).ToList();

//            return new FacultyModel
//            {
//                ActiveRoute = "Faculty",
//                NavItems = NavHelper.GetNavItems("Faculty"),
//                FacultyList = allFaculty,
//                Semesters = GetSemesters(),
//                SearchTerm = search,
//                SelectedSemester = semester,
//            };
//        }

//        private static List<Faculty> GetFaculty() =>
//        [
//            new() {EmpId = "001", Name = "Ms. Maria Arianne Diolingo", Department = "College", Courses = 2},
//            new() {EmpId = "002", Name = "Ms. Joan Maris Rosos", Department = "College", Courses = 2},
//            new() {EmpId = "003", Name = "Ms. Chiara Canque", Department = "College", Courses = 2},
//            new() {EmpId = "004", Name = "Rev. Fr. Keith J. Amodia, SDB.", Department = "College", Courses = 2},
//        ];

//        private static List<string> GetSemesters() =>
//            ["All Semesters", "1", "2", "Summer"];
//    }
//}