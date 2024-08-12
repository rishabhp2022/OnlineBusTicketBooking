namespace OnlineBusTicketBooking.Models
{
    public class SignUpRequest
    {
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string MasterPassword { get; set; }
        public string Role { get; set; }
    }
}
