using System.ComponentModel.DataAnnotations;
using AMS_DBTC_API_v2.Enums;

namespace AMS_DBTC_API_v2.DTOs
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        public Status Status { get; set; } 
    }

    public class AttendanceUpsertDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        public Status Status { get; set; }
    }

    public class AttendanceSummaryDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int TotalClasses { get; set; }
        public int AttendedClasses { get; set; }
        public double AttendancePercentage { get; set; }
    }

    public class AttendanceReportDTO
    {
        public int CourseId { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        public int TotalStudents { get; set; }
        public int PresentStudents { get; set; }
        public int AbsentStudents { get; set; }
    }

    public class StudentAttendanceDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;

        [Required]
        public DateOnly Date { get; set; }
        public Status Status { get; set; }
    } 
}
