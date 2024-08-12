namespace OnlineBusTicketBooking.Models
{
    public class AddRefreshmentRequest
    {
        public int UserID { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}
