using Dynamic_Mapping_System.DTOs;
using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Models;
using Serilog;

namespace Dynamic_Mapping_System.Mappers
{
    public class GoogleReservationDTOMapper : IMapper
    {
        public object Map(object source)
        {
            // Add a log to check the type of the source object
            Log.Information($"Source type: {source?.GetType().Name ?? "null"}");
            // Safely cast source to Reservation
            var googleReservation = source as GoogleReservationDTO;

            if (googleReservation == null)
            {
                // Throw the custom InvalidMappingException with details about the failure
                throw new InvalidMappingException("Invalid object type provided for mapping.",
                    source?.GetType().Name ?? "null", nameof(GoogleReservationDTO));
            }

            // Validate the fields of GoogleReservation
            if (string.IsNullOrWhiteSpace(googleReservation.ReservationId))
            {
                Log.Error("Invalid object type for Google Reservation to Reservation mapping. Expected GoogleReservationId.");
                throw new MappingValidationException("The GoogleReservationId field is missing or empty.", "Reservation", "GoogleReservation");
            }

            if (string.IsNullOrWhiteSpace(googleReservation.CustomerName))
            {
                Log.Error("Invalid object type for Google Reservation to Reservation mapping. Expected GoogleCustomerName.");
                throw new MappingValidationException("The GoogleCustomerName field is missing or empty.", "Reservation", "GoogleReservation");
            }

            if (string.IsNullOrWhiteSpace(googleReservation.DateOfArrival.ToString()))
            {
                Log.Error("Invalid object type for Google Reservation to Reservation mapping. Expected ArrivalDate.");
                throw new MappingValidationException("The ArrivalDate field is missing or empty.", "Reservation", "GoogleReservation");
            }

            if (string.IsNullOrWhiteSpace(googleReservation.DateOfDeparture.ToString()))
            {
                Log.Error("Invalid object type for Google Reservation to Reservation mapping. Expected DepartureDate.");
                throw new MappingValidationException("The DepartureDate field is missing or empty.", "Reservation", "GoogleReservation");
            }

            return new Reservation
            {
                ReservationId = googleReservation.ReservationId,
                CustomerName = googleReservation.CustomerName,
                CheckInDate = googleReservation.DateOfArrival,
                CheckOutDate = googleReservation.DateOfDeparture
            };
        }
    }
}

