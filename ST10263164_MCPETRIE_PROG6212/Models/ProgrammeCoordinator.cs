using System.ComponentModel.DataAnnotations;

namespace ST10263164_MCPETRIE_PROG6212.Models
{
    public class ProgrammeCoordinator
    {
        public int ProgrammeCoordinatorId { get; set; }

        [Required]
        public string ProgrammeCoordinatorPassword { get; set; }
        
        [Required]
        public string ProgrammeCoordinatorName { get; set; }

        [Required]
        public string ProgrammeCoordinatorSurname { get; set; }

        [Required]
        public string ProgrammeCoordinatorEmail { get; set; }

        [Required]
        public string ProgrammeCoordinatorContactNumber { get; set; }


    }
}
