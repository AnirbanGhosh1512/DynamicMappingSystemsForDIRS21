using System;
namespace Dynamic_Mapping_System.DTOs
{
	public class RoomDTO
	{
        public required string Id { get; set; }
        public required string Type { get; set; }
        public required int TotalCapacity { get; set; }
    }
}

