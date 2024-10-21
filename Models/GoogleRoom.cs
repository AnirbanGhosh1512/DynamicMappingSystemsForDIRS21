using System;
namespace Dynamic_Mapping_System.Models
{
	public class GoogleRoom
	{
        public required string GoogleRoomId { get; set; }  
        public required string RoomCategory { get; set; }  
        public required int MaxOccupancy { get; set; }     
    }
}

