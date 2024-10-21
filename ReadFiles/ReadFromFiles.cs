using Dynamic_Mapping_System.Models;
using System.Text.Json;

namespace Dynamic_Mapping_System.ReadFiles
{
	public class ReadFromFiles
	{
		public ReadFromFiles()
		{
		}

        // Function to read and deserialize the JSON file into a Reservation object
        public static GoogleReservation ReadReservationFromJson(string filePath)
        {
            try
            {
                // Read the JSON file as a string
                var jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string into a Reservation object
                var googlereservation = JsonSerializer.Deserialize<GoogleReservation>(jsonString);

                return googlereservation;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or deserializing JSON file: {ex.Message}");
                return null;
            }
        }

        // Function to read and deserialize the JSON file into a Reservation object
        public static GoogleRoom ReadRoomFromJson(string filePath)
        {
            try
            {
                // Read the JSON file as a string
                var jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string into a Reservation object
                var googleRoom = JsonSerializer.Deserialize<GoogleRoom>(jsonString);

                return googleRoom;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or deserializing JSON file: {ex.Message}");
                return null;
            }
        }
    }
}

