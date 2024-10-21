using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Mappers;
using Dynamic_Mapping_System.Models;
using Dynamic_Mapping_System.ReadFiles;
using Xunit;

namespace Dynamic_Mapping_System.Tests
{
	public class GoogleReservationMapperTest
	{

        [Fact]
        public void Map_ValidReservation_ReturnsDIRS21Reservation()
        {
            // Arrange
            var mapper = new DIRS21ReservationMapper();
            var reservation = ReadFromFiles.ReadReservationFromJson(@"Payloads/GoogleReservationPayload.json");

            // Act
            var result = mapper.Map(reservation) as Reservation;

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("14523", result.ReservationId);
            Assert.Equal("Anirban Ghosh", result.CustomerName);
            Assert.NotEqual("2048-11-27", result.CheckInDate.ToString());
        }

        [Fact]
        public void Map_GoogleReservationWithEmptyId_ThrowsMappingValidationException()
        {
            // Arrange
            var mapper = new DIRS21ReservationMapper();
            var reservation = ReadFromFiles.ReadReservationFromJson(@"Payloads/GoogleReservationPayload.json");

            // Act & Assert
            var exception = Assert.Throws<MappingValidationException>(() => mapper.Map(reservation));
            Assert.NotEqual("The GoogleReservationId field is missing or empty.", exception.Message);
        }
    }
}

