using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.Mappers;
using Dynamic_Mapping_System.Models;
using Xunit;

namespace Dynamic_Mapping_System.Tests
{
	public class DIRS21RoomMapperTest
	{
        [Fact]
        public void Map_ValidRoom_ReturnsGoogleRoom()
        {
            // Arrange
            var mapper = new GoogleRoomMapper();
            var room = new Room { RoomId = "578", RoomType = "Deluxe", Capacity = 5 };

            // Act
            var result = mapper.Map(room) as GoogleRoom;

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("555", result.GoogleRoomId);
            Assert.Equal("Deluxe", result.RoomCategory);
            Assert.NotEqual(7, result.MaxOccupancy);
        }

        [Fact]
        public void Map_RoomWithEmptyId_ThrowsMappingValidationException()
        {
            // Arrange
            var mapper = new GoogleRoomMapper();
            var room = new Room { RoomId = " ", RoomType = "RK", Capacity = 2 };

            // Act & Assert
            var exception = Assert.Throws<MappingValidationException>(() => mapper.Map(room));
            Assert.Equal("The ReservationId field is missing or empty.", exception.Message);
        }
    }
}

