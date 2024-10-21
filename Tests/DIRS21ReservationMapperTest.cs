using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Mappers;
using Dynamic_Mapping_System.Models;
using Xunit;

namespace Dynamic_Mapping_System.Tests
{
	public class DIRS21ReservationMapperTest
	{
        [Fact]
        public void Map_ValidReservation_ReturnsGoogleReservation()
        {
            // Arrange
            var mapper = new GoogleReservationMapper();
            var reservation = new Reservation { ReservationId = "123", CustomerName = "John Doe", CheckInDate = Convert.ToDateTime("2019-08-01T00:00:00-07:00") };

            // Act
            var result = mapper.Map(reservation) as GoogleReservation;

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("RES-123", result.GoogleReservationId);
            Assert.Equal("John Doe", result.GoogleCustomerName);
            Assert.NotEqual("2023-10-17", result.ArrivalDate.ToString());
        }

        [Fact]
        public void Map_ReservationWithEmptyId_ThrowsMappingValidationException()
        {
            // Arrange
            var mapper = new GoogleReservationMapper();
            var reservation = new Reservation { ReservationId = " ", CustomerName = "John Doe", CheckInDate = Convert.ToDateTime("2019-08-01T00:00:00-07:00") };

            // Act & Assert
            var exception = Assert.Throws<MappingValidationException>(() => mapper.Map(reservation));
            Assert.Equal("The ReservationId field is missing or empty.", exception.Message);
        }
    }
}

