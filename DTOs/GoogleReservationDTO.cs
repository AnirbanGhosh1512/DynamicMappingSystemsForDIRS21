using System;
namespace Dynamic_Mapping_System.DTOs
{
	public class GoogleReservationDTO
	{
        public required string ReservationId { get; set; }
        public required string CustomerName { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
    }
}

