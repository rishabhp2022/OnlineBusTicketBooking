namespace OnlineBusTicketBooking.Models
{
    public class AddBusDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<AddBusDetails> data { get; set; }
    }
}
