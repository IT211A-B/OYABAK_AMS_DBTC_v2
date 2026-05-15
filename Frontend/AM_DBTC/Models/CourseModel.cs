namespace AM_DBTC.Models
{
    public class Course
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
    }

    public class CourseModel
    {
        public List<Course> Courses{ get; set; } = new();
        public List<string> Semesters { get; set; } = new();
        public string SearchTerm { get; set; } = string.Empty;
        public string SelectedSemester { get; set; } = "All Semesters";
    }
}