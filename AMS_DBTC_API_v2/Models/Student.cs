using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AMS_DBTC_API_v2.Enums;

namespace AMS_DBTC_API_v2.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        
        [Required]
        [StringLength(20)]
        public string RollNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;   
        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public Sex sex { get; set; }
        [Required]
        public YearLevel yearLevel { get; set; }
        [Required]
        public string Program { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
