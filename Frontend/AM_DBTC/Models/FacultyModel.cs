namespace AM_DBTC.Models
{
    public class Faculty
    {
        public string EmpId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Courses { get; set; }
    }

    public class FacultyModel
    {
        public List<Faculty> Faculties { get; set; } = new();
        public List<string> Semesters { get; set; } = new();
        public string SearchTerm { get; set; } = string.Empty;
        public string SelectedSemester { get; set; } = "All Semesters";
    }
}