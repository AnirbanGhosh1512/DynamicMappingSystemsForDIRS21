using System;
using Dynamic_Mapping_System.DTOs;
using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Models;
using Serilog;

namespace Dynamic_Mapping_System.Mappers
{
	public class DIRS21RoomMapper:IMapper
	{
        public object Map(object source)
        {
            // Add a log to check the type of the source object
            Log.Information($"Source type: {source?.GetType().Name ?? "null"}");
            // Safely cast source to Reservation
            var room = source as Room;

            if (room == null)
            {
                // Throw the custom InvalidMappingException with details about the failure
                throw new InvalidMappingException("Invalid object type provided for mapping.",
                    source?.GetType().Name ?? "null", nameof(Room));
            }

            // Validate the fields of Reservation
            if (string.IsNullOrWhiteSpace(room.RoomId))
            {
                Log.Error("Invalid object type for Room to Google Room mapping. Expected RoomId.");
                throw new MappingValidationException("The RoomId field is missing or empty.", "Room", "GoogleRoom");
            }

            if (string.IsNullOrWhiteSpace(room.RoomType))
            {
                Log.Error("Invalid object type for Room to Google Room mapping. Expected RoomType.");
                throw new MappingValidationException("The RoomType field is missing or empty.", "Room", "GoogleRoom");
            }

            if (string.IsNullOrWhiteSpace(room.Capacity.ToString()))
            {
                Log.Error("Invalid object type for Room to Google Room mapping. Expected Capacity.");
                throw new MappingValidationException("The Capacity field is missing or empty.", "Room", "GoogleRoom");
            }

            // Proceed with the mapping if casting succeeded
            return new RoomDTO
            {
                Id = room.RoomId,
                Type = room.RoomType,
                TotalCapacity = room.Capacity
            };
        }
    }
}

