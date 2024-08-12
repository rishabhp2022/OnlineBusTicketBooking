namespace OnlineBusTicketBooking.Models
{
    public class AddBusDetailsRequest
    {
        public string BusName { get; set; }
        public string BusNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
    }
}
