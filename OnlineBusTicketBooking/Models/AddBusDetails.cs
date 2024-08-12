using System.ComponentModel.DataAnnotations;

namespace OnlineBusTicketBooking.Models
{
    public class AddBusDetails
    {
        [Key]
        public int id { get; set; }
        public string BusName { get; set; }
        public string BusNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public string TicketPrice { get; set; }
        public string Seat1 { get; set; }
        public string Seat2 { get; set; }
        public string Seat3 { get; set; }
        public string Seat4 { get; set; }
        public string Seat5 { get; set; }
        public string Seat6 { get; set; }
        public string Seat7 { get; set; }
        public string Seat8 { get; set; }
        public string Seat9 { get; set; }
        public string Seat10 { get; set; }
    }
}
