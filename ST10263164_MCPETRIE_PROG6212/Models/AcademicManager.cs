using System.ComponentModel.DataAnnotations;

namespace ST10263164_MCPETRIE_PROG6212.Models
{
    public class AcademicManager
    {
        public int AcademicManagerId { get; set; }

        [Required]
        public string AcademicManagerPassword { get; set; }

        [Required]
        public string AcademicManagerName { get; set; }

        [Required]
        public string AcademicManagerSurname { get; set; }

        [Required]
        public string AcademicManagerEmail { get; set; }

        [Required]
        public string AcademicManagerContactNumber { get; set; }
    }
}
