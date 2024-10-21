using System;
namespace Dynamic_Mapping_System.DTOs
{
	public class ReservationDTO
	{
        public required string Id { get; set; }
        public required string Name { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}

