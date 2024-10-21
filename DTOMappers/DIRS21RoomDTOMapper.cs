using System;
using Dynamic_Mapping_System.DTOs;
using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Models;
using Serilog;

namespace Dynamic_Mapping_System.Mappers
{
        public class DIRS21RoomDTOMapper : IMapper
        {
            public object Map(object source)
            {
                // Add a log to check the type of the source object
                Log.Information($"Source type: {source?.GetType().Name ?? "null"}");
                // Safely cast source to room
                var roomDTO = source as RoomDTO;

                if (roomDTO == null)
                {
                    // Throw the custom InvalidMappingException with details about the failure
                    throw new InvalidMappingException("Invalid object type provided for mapping.",
                        source?.GetType().Name ?? "null", nameof(roomDTO));
                }

                // Validate the fields of room
                if (string.IsNullOrWhiteSpace(roomDTO.Id))
                {
                    Log.Error("Invalid object type for room to Google room mapping. Expected roomId.");
                    throw new MappingValidationException("The roomId field is missing or empty.", "room", "Googleroom");
                }

                if (string.IsNullOrWhiteSpace(roomDTO.Type))
                {
                    Log.Error("Invalid object type for room to Google room mapping. Expected CustomerName.");
                    throw new MappingValidationException("The CustomerName field is missing or empty.", "room", "Googleroom");
                }

                if (string.IsNullOrWhiteSpace(roomDTO.TotalCapacity.ToString()))
                {
                    Log.Error("Invalid object type for room to Google room mapping. Expected CheckInDate.");
                    throw new MappingValidationException("The CheckInDate field is missing or empty.", "room", "Googleroom");
                }

                // Proceed with the mapping if casting succeeded
                return new GoogleRoom
                {
                    GoogleRoomId = roomDTO.Id,
                    RoomCategory = roomDTO.Type,
                    MaxOccupancy = roomDTO.TotalCapacity
                };
            }
    }
}

