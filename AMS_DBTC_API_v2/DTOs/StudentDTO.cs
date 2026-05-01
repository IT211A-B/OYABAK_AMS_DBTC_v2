using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using AMS_DBTC_API_v2.Enums;

namespace AMS_DBTC_API_v2.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string RollNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Sex sex { get; set; }
        public YearLevel YearLevel { get; set; }
    }
    public class CreateStudentDTO
    {
        [Required]
        [StringLength(20)]
        public string RollNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        public Sex sex { get; set; }
        public YearLevel yearLevel { get; set; }
        public string Program { get; set; } = string.Empty;

        public int CourseId { get; set; }
    }

    public class UpdateStudentDTO
    {
        [Required]
        [StringLength(20)]
        public string RollNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        public Sex sex { get; set; }
        public YearLevel yearLevel { get; set; }

        public int CourseId { get; set; }
    }
}
