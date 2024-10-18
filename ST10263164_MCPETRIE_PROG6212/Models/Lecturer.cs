using System.ComponentModel.DataAnnotations;

namespace ST10263164_MCPETRIE_PROG6212.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string LecturerPassword { get; set; }
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }
        public string LecturerEmail { get; set; }
        public string LecturerContactNumber { get; set; }

        //public int User_ID { get; set; }
        //public string User_Role { get; set; }

    }
}
