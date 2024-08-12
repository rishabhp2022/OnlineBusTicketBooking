namespace OnlineBusTicketBooking.Models
{
    public class InsertFeedbackRequest
    {
        public int UserID { get; set; }
        public string JourneyExperience { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
