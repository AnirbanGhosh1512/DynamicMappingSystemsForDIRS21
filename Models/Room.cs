using System;
namespace Dynamic_Mapping_System.Models
{
	public class Room
	{
        public required string RoomId { get; set; }
        public required string RoomType { get; set; }
        public required int Capacity { get; set; }
    }
}

