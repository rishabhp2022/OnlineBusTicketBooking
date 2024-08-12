namespace OnlineBusTicketBooking.Models
{
    public class SignInResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public SignIn data { get; set; }
    }
}
