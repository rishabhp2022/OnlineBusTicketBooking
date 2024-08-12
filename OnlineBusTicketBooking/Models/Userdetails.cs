using System.ComponentModel.DataAnnotations;

namespace OnlineBusTicketBooking.Models
{
    public class Userdetails
    {
        [Key]
        public int UserID { get; set; }
        public string InsertionDate { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
