using AMS_DBTC_API_v2.Enums;

namespace AMS_DBTC_API_v2.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateOnly Date { get; set; }
        public Status Status { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
