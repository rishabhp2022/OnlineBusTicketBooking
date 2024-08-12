using System.ComponentModel.DataAnnotations;

namespace OnlineBusTicketBooking.Models
{
    public class FeedDetails
    {
        [Key]
        public int FeedbackID { get; set; }
        public int UserID { get; set; }
        public string JourneyExperience { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
