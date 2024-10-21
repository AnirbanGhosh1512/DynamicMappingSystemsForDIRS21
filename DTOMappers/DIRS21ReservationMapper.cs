using Dynamic_Mapping_System.DTOs;
using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Models;
using Serilog;

namespace Dynamic_Mapping_System.Mappers
{
	public class DIRS21ReservationMapper:IMapper
	{
        public object Map(object source)
        {
            // Add a log to check the type of the source object
            Log.Information($"Source type: {source?.GetType().Name ?? "null"}");
            // Safely cast source to Reservation
            var reservation = source as Reservation;

            if (reservation == null)
            {
                // Throw the custom InvalidMappingException with details about the failure
                throw new InvalidMappingException("Invalid object type provided for mapping.",
                    source?.GetType().Name ?? "null", nameof(Reservation));
            }

            // Validate the fields of Reservation
            if (string.IsNullOrWhiteSpace(reservation.ReservationId))
            {
                Log.Error("Invalid object type for Reservation to Google Reservation mapping. Expected ReservationId.");
                throw new MappingValidationException("The ReservationId field is missing or empty.", "Reservation", "GoogleReservation");
            }

            if (string.IsNullOrWhiteSpace(reservation.CustomerName))
            {
                Log.Error("Invalid object type for Reservation to Google Reservation mapping. Expected CustomerName.");
                throw new MappingValidationException("The CustomerName field is missing or empty.", "Reservation", "GoogleReservation");
            }

            if (string.IsNullOrWhiteSpace(reservation.CheckInDate.ToString()))
            {
                Log.Error("Invalid object type for Reservation to Google Reservation mapping. Expected CheckInDate.");
                throw new MappingValidationException("The CheckInDate field is missing or empty.", "Reservation", "GoogleReservation");
            }

            if (string.IsNullOrWhiteSpace(reservation.CheckOutDate.ToString()))
            {
                Log.Error("Invalid object type for Reservation to Google Reservation mapping. Expected CheckOutDate.");
                throw new MappingValidationException("The CheckOutDate field is missing or empty.", "Reservation", "GoogleReservation");
            }

            // Proceed with the mapping if casting succeeded
            return new ReservationDTO
            {
                Id = reservation.ReservationId,
                Name = reservation.CustomerName,
                DateIn = reservation.CheckInDate,
                DateOut = reservation.CheckOutDate
            };
        }

    }
}

