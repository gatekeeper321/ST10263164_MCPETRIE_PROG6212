/*
 * WILLIAM MCPETRIE
 * ST10263164
 * PROG6212
 * POE PART 3
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10263164_MCPETRIE_PROG6212.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        public string ContractId { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        public int HourlyRate { get; set; }

        public int ClaimTotal { get; set; }

        public byte[]? SupportingDocument { get; set; }

        [Required]
        public int LecturerId { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool ProgrammeCoordinatorApproval { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool AcademicManagerApproval { get; set; }

        [Required]
        public string OverallAproval { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }

        public Claim()
        {
            ClaimDate = DateTime.Now;
            OverallAproval = "pending"; // sets the default value of the OverallAproval to pending, changed in home controller automatically if approval criteria met
        }

        public Claim(int hoursWorked, int hourlyRate)  
        {
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
            ClaimDate = DateTime.Now;

            Console.WriteLine($"HoursWorked: {HoursWorked}, HourlyRate: {HourlyRate}");
            Console.WriteLine($"OverallAproval: {OverallAproval}");
        }
    }

}


