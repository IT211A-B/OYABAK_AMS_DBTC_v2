namespace AM_DBTC.Models
{
    public class AttendanceRecord
    {
        public string UserName { get; set; } = "";
        public DateTime Date { get; set; }
        public string Day { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // Presnt, Absent, and Leave
        public string Time { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
    }

    public class AttendanceModel
    {
        public int TotalClasses { get; set; }
        public int ClassesPresent { get; set; }
        public int ClassesAbsent { get; set; }
        public List<AttendanceRecord> Records { get; set; } = new();
        public List<string> Courses { get; set; } = new();
        public List<string> Months { get; set; } = new();
        public string SelectedCourse { get; set; } = string.Empty;
        public string SelectedMonth { get; set; } = string.Empty;
        public string SearchUserName { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
    }
}