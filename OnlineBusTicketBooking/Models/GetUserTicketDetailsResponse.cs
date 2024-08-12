namespace OnlineBusTicketBooking.Models
{
    public class GetUserTicketDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<TicketDetails> data { get; set; }
    }
}
