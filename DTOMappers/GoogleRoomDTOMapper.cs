using System;
using Dynamic_Mapping_System.DTOs;
using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Models;
using Serilog;

namespace Dynamic_Mapping_System.Mappers
{
	public class GoogleRoomDTOMapper:IMapper
	{
        public object Map(object source)
        {
            // Add a log to check the type of the source object
            Log.Information($"Source type: {source?.GetType().Name ?? "null"}");
            // Safely cast source to Room
            var googleRoom = source as GoogleRoomDTO;

            if (googleRoom == null)
            {
                // Throw the custom InvalidMappingException with details about the failure
                throw new InvalidMappingException("Invalid object type provided for mapping.",
                    source?.GetType().Name ?? "null", nameof(GoogleRoom));
            }

            // Validate the fields of GoogleRoom
            if (string.IsNullOrWhiteSpace(googleRoom.GoogleRoomId))
            {
                Log.Error("Invalid object type for Google Room to Room mapping. Expected GoogleRoomId.");
                throw new MappingValidationException("The GoogleRoomId field is missing or empty.", "Room", "GoogleRoom");
            }

            if (string.IsNullOrWhiteSpace(googleRoom.RoomCategory))
            {
                Log.Error("Invalid object type for Google Room to Room mapping. Expected RoomCategory.");
                throw new MappingValidationException("The RoomCategory field is missing or empty.", "Room", "GoogleRoom");
            }

            if (string.IsNullOrWhiteSpace(googleRoom.MaxOccupancy.ToString()))
            {
                Log.Error("Invalid object type for Google Room to Room mapping. Expected MaxOccupancy.");
                throw new MappingValidationException("The MaxOccupancy field is missing or empty.", "Room", "GoogleRoom");
            }

            return new Room
            {
                RoomId = googleRoom.GoogleRoomId,
                RoomType = googleRoom.RoomCategory,
                Capacity = googleRoom.MaxOccupancy
            };
        }
    }
}

