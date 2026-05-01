using System.ComponentModel.DataAnnotations;

namespace AMS_DBTC_API_v2.Models
{
    public class Teacher
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
}
