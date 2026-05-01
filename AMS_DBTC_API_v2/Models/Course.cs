using System.ComponentModel.DataAnnotations;

namespace AMS_DBTC_API_v2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;

        public List<Student> Students { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();  
    }
}
