namespace OnlineBusTicketBooking.Models
{
    public class GetRefreshmentsDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Total { get; set; }
        public List<RefreshmentsDetails> data { get; set; }
    }
}
