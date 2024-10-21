using System;
using Dynamic_Mapping_System.Models;

namespace Dynamic_Mapping_System.Validators
{
    public class ReservationValidator : IValidator<Reservation>
    {
        public string ValidationErrorMessage { get; private set; }

        public bool Validate(Reservation reservation)
        {
            if (reservation == null)
            {
                ValidationErrorMessage = "Reservation cannot be null.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(reservation.ReservationId))
            {
                ValidationErrorMessage = "Reservation ID cannot be empty.";
                return false;
            }

            if (reservation.CheckInDate >= reservation.CheckOutDate)
            {
                ValidationErrorMessage = "Check-out date must be after the check-in date.";
                return false;
            }

            return true;
        }
    }

}

