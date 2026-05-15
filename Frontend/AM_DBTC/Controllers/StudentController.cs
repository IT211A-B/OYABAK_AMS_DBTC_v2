using Microsoft.AspNetCore.Mvc;
using AM_DBTC.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AM_DBTC.Services;

namespace AM_DBTC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> StudentView(string search = "", string semester = "All Semesters", string branch = "All Branches")
        {
            var model = await _studentService.GetStudentsAsync(search, semester, branch);
            return View("StudentView", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Student student)
        {
            await _studentService.AddStudentAsync(student);
            return RedirectToAction("StudentView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            await _studentService.EditStudentAsync(student);
            return RedirectToAction("StudentView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string rollNo)
        {
            await _studentService.DeleteStudentAsync(rollNo);
            return RedirectToAction("StudentView");
        }
    }
}





















//namespace AM_DBTC.Controllers
//{
//    public class StudentController : Controller
//    {
//        public IActionResult StudentView(string search = "", string semester = "All Semesters", string branch = "All Branches")
//        {
//            var model = BuildModel(search, semester, branch);
//            return View("StudentView", model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Add(Student student)
//        {
//            return RedirectToAction("StudentView", "Student");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Student student)
//        {
//            return RedirectToAction("StudentView", "Student");
//        }

//        private StudentModel BuildModel(string search, string semester, string branch)
//        {
//            var allStudents = GetStudents();

//            if (!string.IsNullOrWhiteSpace(search))
//                allStudents = allStudents.Where(s =>
//                    s.Name.Contains(search, System.StringComparison.OrdinalIgnoreCase) || s.RollNo.Contains(search, System.StringComparison.OrdinalIgnoreCase)).ToList();

//            if (semester != "All Semesters")
//                allStudents = allStudents.Where(s => s.Semester.ToString() == semester).ToList();

//            if (branch != "All Branches")
//                allStudents = allStudents.Where(s => s.Course == branch).ToList();

//            return new StudentModel
//            {
//                ActiveRoute = "Students",
//                NavItems = NavHelper.GetNavItems("Students"),
//                Students = allStudents,
//                Semesters = GetSemesters(),
//                Branches = GetBranches(),
//                SearchTerm = search,
//                SelectedSemester = semester,
//                SelectedBranch = branch,
//            };
//        }

//        private static List<Student> GetStudents() =>
//        [
//            new() { RollNo = "24060176", Name = "Oyabak Oyabak", Semester = 2, Course = "BSIT" },
//            new() { RollNo = "24060177", Name = "Leachim Cabingatan Dela Cerna", Semester = 2, Course = "BSIT" },
//            new() { RollNo = "24060178", Name = "Bryan Empes Quino", Semester = 2, Course = "BSIT" },
//            new() { RollNo = "24060179", Name = "Kierstien Servan Verano", Semester = 2, Course = "BSIT" },
//        ];

//        private static List<string> GetSemesters() =>
//            ["All Semesters", "1", "2", "Summer"];

//        private static List<string> GetBranches() =>
//            ["All Branches", "BSIT", "BSME", "TVET"];
//    }
//}