namespace AM_DBTC.Models
{
    public class Student
    {
        public string RollNo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Semester { get; set; }
        public string Course { get; set; } = string.Empty;
    }

    public class StudentModel
    {
        public List<Student> Students { get; set; } = new();
        public List<string> Semesters { get; set; } = new();
        public List<string> Branches { get; set; } = new();
        public string SearchTerm { get; set; } = string.Empty;
        public string SelectedSemester { get; set; } = "All Semesters";
        public string SelectedBranch { get; set; } = "All Branches";
    }
}