using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10263164_MCPETRIE_PROG6212.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        [Required]
        public string ContractId { get; set; }

        private int _hoursWorked;
        [Required]
        public int HoursWorked
        {
            get { return _hoursWorked; }
            set
            {
                _hoursWorked = value;
                CalculateClaimTotal(); // Recalculate when HoursWorked is set
            }
        }

        private int _hourlyRate;
        [Required]
        public int HourlyRate
        {
            get { return _hourlyRate; }
            set
            {
                _hourlyRate = value;
                CalculateClaimTotal(); // Recalculate when HourlyRate is set
            }
        }

        public int ClaimTotal { get; private set; } // Storing this in the DB

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
            OverallAproval = "pending";
            ClaimDate = DateTime.Now;
            HourlyRate = 0;
            HoursWorked = 0;
            CalculateClaimTotal(); // Initial calculation
        }

        public Claim(int hourlyRate, int hoursWorked)
        {
            OverallAproval = "pending";
            ClaimDate = DateTime.Now;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
            CalculateClaimTotal(); // Initial calculation
        }

        private void CalculateClaimTotal()
        {
            ClaimTotal = HourlyRate * HoursWorked;
        }
    }

}


