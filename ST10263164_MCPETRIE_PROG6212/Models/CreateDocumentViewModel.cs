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
    public class ClaimDocumentViewModel
    {
        public int ClaimId { get; set; }
        public string ContractId { get; set; }
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public int ClaimTotal { get; set; }
        public byte[]? SupportingDocument { get; set; }
        public DateTime ClaimDate { get; set; }

        public int LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }
        public string LecturerEmail { get; set; }
        public string LecturerContactNumber { get; set; }
    }
}


