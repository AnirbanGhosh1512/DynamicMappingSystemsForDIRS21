using Dynamic_Mapping_System.Models;
using Dynamic_Mapping_System.Services;
using Dynamic_Mapping_System.Validators;
using Dynamic_Mapping_System.Exceptions;
using Dynamic_Mapping_System.ReadFiles;
using Serilog;
using Dynamic_Mapping_System.DTOs;

namespace Dynamic_Mapping_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reservation Mechanism @Anirban 19.10.2024
            ReservationMechanismDIRS21ToGoogle();
            ReservationMechanismGoogleToDIRS21();

            // Room Mechanism @Anirban 19.10.2024
            RoomMechanismDIRS21ToGoogle();
            RoomMechanismGoogleToDIRS21();

        }

       
        private static void ReservationMechanismGoogleToDIRS21()
        {
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/mappinglog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");

            try
            {
                var handler = new MapHandler();

                // Test Google to GoogleReservationDTO mapping
                var googleReservationData = ReadFromFiles.ReadReservationFromJson(@"Payloads/GoogleReservationPayload.json");
                Log.Information("Attempting to map GoogleReservation to GoogleReservationDTO");
                var googleReservationDTO = handler.Map(googleReservationData, "Google.Reservation", "DTO.GoogleReservationDTO") as GoogleReservationDTO;

                if (googleReservationDTO != null)
                {
                    Log.Information("Mapping from Google Reservation to Google ReservationDTO successful.");
                    Console.WriteLine($"Mapped to ReservationDTO: {googleReservationDTO.ReservationId}, {googleReservationDTO.CustomerName}");
                }
                else
                    Log.Information("Mapping from Google Reservation to Google ReservationDTO failed.");

                // Map Google ReservationDTO to DIRS21 Reservation
                Log.Information("Attempting to map GoogleReservationDTO to DIRS21Reservation");
                var dirs21Reservation = handler.Map(googleReservationDTO, "DTO.GoogleReservationDTO", "DIRS21.Reservation") as Reservation;


                if (dirs21Reservation != null)
                {
                    Console.WriteLine($"Mapped to DIRS21: {dirs21Reservation.ReservationId}, {dirs21Reservation.CustomerName}");
                }
                else
                {
                    Console.WriteLine("Failed to map Google ReservationDTO to DIRS21 Reservation.");
                }
            }
            catch (MappingValidationException ex)
            {
                // Handle validation exception and log it
                Log.Error(ex, $"Validation error during mapping: {ex.Message}");
                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (InvalidMappingException ex)
            {
                // Handle other mapping exceptions and log it
                Log.Error(ex, $"Mapping error: {ex.Message}");
                Console.WriteLine($"Mapping error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions and log it
                Log.Fatal(ex, "An unexpected error occurred");
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Log.Information("Application Ending...");
                Log.CloseAndFlush();
            }
        }

        private static void ReservationMechanismDIRS21ToGoogle()
        {
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/mappinglog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");

            try
            {
                var handler = new MapHandler();

                // Test DIRS21 Reservation to DIRS21 ReservationDTO mapping
                var dirs21ReservationData = new Reservation { ReservationId = "123", CustomerName = "John Doe" };
                Log.Information("Attempting to map Reservation to ReservationDTO");
                var reservationDTO = handler.Map(dirs21ReservationData, "Model.Reservation", "DTO.ReservationDTO") as ReservationDTO;

                if (reservationDTO != null)
                {
                    Log.Information("Mapping from DIRS21 Reservation to ReservationDTO successful.");
                    Console.WriteLine($"Mapped to ReservationDTO: {reservationDTO.Id}, {reservationDTO.Name}");
                }
                else 
                    Log.Information("Mapping from DIRS21 Reservation to ReservationDTO failed.");

                // Map ReservationDTO to GoogleReservation
                Log.Information("Attempting to map ReservationDTO to GoogleReservation");
                var googleReservation = handler.Map(reservationDTO, "DTO.ReservationDTO", "Google.Reservation") as Models.GoogleReservation;


                if (googleReservation != null)
                {
                    Console.WriteLine($"Mapped to Google: {googleReservation.GoogleReservationId}, {googleReservation.GoogleCustomerName}");
                }
                else
                {
                    Console.WriteLine("Failed to map DIRS21 ReservationDTO to Google Reservation.");
                }
            }
            catch (MappingValidationException ex)
            {
                // Handle validation exception and log it
                Log.Error(ex, $"Validation error during mapping: {ex.Message}");
                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (InvalidMappingException ex)
            {
                // Handle other mapping exceptions and log it
                Log.Error(ex, $"Mapping error: {ex.Message}");
                Console.WriteLine($"Mapping error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions and log it
                Log.Fatal(ex, "An unexpected error occurred");
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Log.Information("Application Ending...");
                Log.CloseAndFlush();
            }
        }

        private static void RoomMechanismDIRS21ToGoogle()
        {
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/mappinglog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");

            try
            {
                var handler = new MapHandler();

                // Test DIRS21 Room to DIRS21 ReservationDTO mapping
                var dirs21RoomData = new Room { RoomId = "123", RoomType = "Delux", Capacity = 3 };
                Log.Information("Attempting to map Room to RoomDTO");
                var roomDTO = handler.Map(dirs21RoomData, "Model.Room", "DTO.RoomDTO") as RoomDTO;

                if (roomDTO != null)
                {
                    Log.Information("Mapping from DIRS21 Room to RoomDTO successful.");
                    Console.WriteLine($"Mapped to RoomDTO: {roomDTO.Id}, {roomDTO.Type}, {roomDTO.TotalCapacity}");
                }
                else
                    Log.Information("Mapping from DIRS21 Room to RoomDTO failed.");

                // Map ReservationDTO to GoogleReservation
                Log.Information("Attempting to map RoomDTO to GoogleRoom");
                var googleRoom = handler.Map(roomDTO, "DTO.RoomDTO", "Google.Room") as GoogleRoom;


                if (googleRoom != null)
                {
                    Console.WriteLine($"Mapped to Google: {googleRoom.GoogleRoomId}, {googleRoom.RoomCategory}");
                }
                else
                {
                    Console.WriteLine("Failed to map DIRS21 RoomDTO to GoogleRoom.");
                }
            }
            catch (MappingValidationException ex)
            {
                // Handle validation exception and log it
                Log.Error(ex, $"Validation error during mapping: {ex.Message}");
                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (InvalidMappingException ex)
            {
                // Handle other mapping exceptions and log it
                Log.Error(ex, $"Mapping error: {ex.Message}");
                Console.WriteLine($"Mapping error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions and log it
                Log.Fatal(ex, "An unexpected error occurred");
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Log.Information("Application Ending...");
                Log.CloseAndFlush();
            }
        }

        private static void RoomMechanismGoogleToDIRS21()
        {
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/mappinglog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");

            try
            {
                var handler = new MapHandler();

                // Test Google to GoogleReservationDTO mapping
                var googleRoomData = ReadFromFiles.ReadRoomFromJson(@"Payloads/GoogleRoomPayload.json");
                Log.Information("Attempting to map GoogleRoom to GoogleRoomDTO");
                var googleRoomDTO = handler.Map(googleRoomData, "Google.Room", "DTO.GoogleRoomDTO") as GoogleRoomDTO;

                if (googleRoomDTO != null)
                {
                    Log.Information("Mapping from Google Room to Google RoomDTO successful.");
                    Console.WriteLine($"Mapped to RoomDTO: {googleRoomDTO.GoogleRoomId}, {googleRoomDTO.RoomCategory}, {googleRoomDTO.MaxOccupancy}");
                }
                else
                    Log.Information("Mapping from Google Reservation to Google ReservationDTO failed.");

                // Map Google RoomDTO to DIRS21 Room
                Log.Information("Attempting to map GoogleRoomDTO to DIRS21Room");
                var dirs21Room = handler.Map(googleRoomDTO, "DTO.GoogleRoomDTO", "Model.Room") as Room;


                if (dirs21Room != null)
                {
                    Console.WriteLine($"Mapped to DIRS21: {dirs21Room.RoomId}, {dirs21Room.RoomType}, {dirs21Room.Capacity}");
                }
                else
                {
                    Console.WriteLine("Failed to map Google RoomDTO to DIRS21 Room.");
                }
            }
            catch (MappingValidationException ex)
            {
                // Handle validation exception and log it
                Log.Error(ex, $"Validation error during mapping: {ex.Message}");
                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (InvalidMappingException ex)
            {
                // Handle other mapping exceptions and log it
                Log.Error(ex, $"Mapping error: {ex.Message}");
                Console.WriteLine($"Mapping error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions and log it
                Log.Fatal(ex, "An unexpected error occurred");
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Log.Information("Application Ending...");
                Log.CloseAndFlush();
            }
        }

    }
}


