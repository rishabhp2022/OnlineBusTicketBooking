namespace OnlineBusTicketBooking.Models
{
    public class UpdateSeatStatusRequest
    {
        public int ID { get; set; }
        public int SeatNo { get; set; }
        public string Status { get; set; }
    }
}
