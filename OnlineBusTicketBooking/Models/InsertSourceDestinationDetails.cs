using System.ComponentModel.DataAnnotations;

namespace OnlineBusTicketBooking.Models
{
    public class InsertSourceDestinationDetails
    {
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string BusName { get; set; }
        [Required]
        public string BusNumber { get; set; }
        [Required]
        public string TicketPrice { get; set; }
    }

    //public class GetSourceDestinationDetailsRequest
    //{
    //    public string Source { get; set; }
    //    public string Destination { get; set; }
    //}
}

