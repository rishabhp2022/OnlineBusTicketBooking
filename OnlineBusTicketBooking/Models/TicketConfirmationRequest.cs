namespace OnlineBusTicketBooking.Models
{
    public class TicketConfirmationRequest
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string BusName { get; set; }
        public string BusNumber { get; set; }
        public string SeatNumber { get; set; }
        public string Value { get; set; }
        public int UserID { get; set; }
        public string TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string Expiry { get; set; }
    }
}
