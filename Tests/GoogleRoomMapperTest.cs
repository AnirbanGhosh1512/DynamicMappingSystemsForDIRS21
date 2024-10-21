using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Mappers;
using Dynamic_Mapping_System.Models;
using Dynamic_Mapping_System.ReadFiles;
using Xunit;

namespace Dynamic_Mapping_System.Tests
{
	public class GoogleRoomMapperTest
	{
        [Fact]
        public void Map_ValidReservation_ReturnsDIRS21Reservation()
        {
            // Arrange
            var mapper = new DIRS21RoomMapper();
            var room = ReadFromFiles.ReadRoomFromJson(@"Payloads/GoogleRoomPayload.json");

            // Act
            var result = mapper.Map(room) as Room;

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("14523", result.RoomId);
            Assert.Equal("Deluxe", result.RoomType);
            Assert.NotEqual(7, result.Capacity);
        }

        [Fact]
        public void Map_GoogleReservationWithEmptyId_ThrowsMappingValidationException()
        {
            // Arrange
            var mapper = new DIRS21RoomMapper();
            var room = ReadFromFiles.ReadRoomFromJson(@"Payloads/GoogleReservationPayload.json");

            // Act & Assert
            var exception = Assert.Throws<MappingValidationException>(() => mapper.Map(room));
            Assert.NotEqual("The GoogleRoomId field is missing or empty.", exception.Message);
        }
    }
}

