using System;
namespace Dynamic_Mapping_System.DTOs
{
	public class GoogleRoomDTO
	{
        public required string GoogleRoomId { get; set; }
        public required string RoomCategory { get; set; }
        public required int MaxOccupancy { get; set; }
    }
}

