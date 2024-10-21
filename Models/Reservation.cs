using System;
namespace Dynamic_Mapping_System.Models
{
    public class Reservation
    {
        public required string ReservationId { get; set; }
        public required string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }      
    }
}

