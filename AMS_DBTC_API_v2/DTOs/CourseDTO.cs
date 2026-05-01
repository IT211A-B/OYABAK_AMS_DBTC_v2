using System.ComponentModel.DataAnnotations;

namespace AMS_DBTC_API_v2.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }

    public class CreateCourseDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
    }

    public class UpdateCourseDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
    }

    public class CourseWithStudentsDTO
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }

    public class CourseWithTeachersDTO
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
        public List<TeacherDTO> Teachers { get; set; } = new List<TeacherDTO>();
    }

    public class CourseWithStudentsAndTeachersDTO
    {
        public int CourseId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
        public List<TeacherDTO> Teachers { get; set; } = new List<TeacherDTO>();
    }
}
