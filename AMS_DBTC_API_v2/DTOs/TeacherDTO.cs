using System.ComponentModel.DataAnnotations;

namespace AMS_DBTC_API_v2.DTOs
{
        public class TeacherDTO
        {
            public int Id { get; set; }
            [Required]
            [StringLength(20)]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [StringLength(20)]
            public string LastName { get; set; } = string.Empty;

            [StringLength(20)]
            public string? MiddleName { get; set; }

            [Required]
            [StringLength(50)]
            public string Email { get; set; } = string.Empty;

            public string Department { get; set; } = string.Empty;

        }
        public class CreateTeacherDTO
        {
            [Required]
            [StringLength(20)]
            public string FirstName { get; set; } = string.Empty;
            [Required]
            [StringLength(20)]
            public string LastName { get; set; } = string.Empty;
            [StringLength(20)]
            public string? MiddleName { get; set; }
            [Required]
            [StringLength(50)]
            public string Email { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
        }

        public class UpdateTeacherDTO
        {
            [Required]
            [StringLength(20)]
            public string FirstName { get; set; } = string.Empty;
            [Required]
            [StringLength(20)]
            public string LastName { get; set; } = string.Empty;
            [StringLength(20)]
            public string? MiddleName { get; set; }
            [Required]
            [StringLength(50)]
            public string Email { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
        }

        public class TeacherResponseDTO
        {
            public int Id { get; set; }

            [Required]
            [StringLength(20)]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [StringLength(20)]
            public string LastName { get; set; } = string.Empty;

            [Required]
            [StringLength(20)]
            public string? MiddleName { get; set; }
            public string Email { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
        }
}
