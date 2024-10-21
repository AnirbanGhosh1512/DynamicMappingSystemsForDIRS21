using System;
using Dynamic_Mapping_System.DTOs;
using System.Text.Json;

namespace Dynamic_Mapping_System.Models
{
	public class GoogleReservation
	{
        public required string GoogleReservationId { get; set; }
        public required string GoogleCustomerName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

