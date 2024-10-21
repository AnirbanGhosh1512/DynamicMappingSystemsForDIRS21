# DIRS21-DynamicMappingSystem

Dynamic Mapping System - DIRS21 to External Systems:
This project implements a dynamic mapping system for the DIRS21 platform, providing a flexible and scalable way to map data between DIRS21 internal models and external models used by partners (e.g., Google). The system is designed to be extensible, following SOLID principles and leveraging design patterns like the Factory Pattern to handle multiple mappings between internal models, DTOs (Data Transfer Objects), and external models.

Project Structure:

Core Components:

Models:

DIRS21 Models: Internal models representing data within the DIRS21 system.
DTO (Data Transfer Objects): Intermediary objects used to decouple internal models from external systems.
Partner Models: External models representing data formats used by partners like Google.

Mappers:

Mapper Interface (IModelMapper): Defines the contract for all mappers, allowing flexibility in adding new mappers for different models.
Concrete Mappers: Implementations of the IModelMapper interface that handle specific model-to-model mappings (e.g., Room to GoogleRoom via RoomDTO).

MapHandler:

Centralized handler that retrieves and applies mappers based on the source and target model types.
It supports both single-step mappings (e.g., internal to external) and multi-step mappings (e.g., internal → DTO → external).


Directory Structure:

├── Models
│   ├── Models
│   │   ├── Reservation.cs
│   │   ├── Room.cs
│   │   ├── GoogleReservation.cs
│   │   ├── GoogleRoom.cs
│   ├── DTO
│   │   ├── ReservationDTO.cs
│   │   ├── RoomDTO.cs
├── DTOMappers
│   ├── IMapper.cs
│   ├── DIRS21ReservationDTOMapper.cs
│   ├── DIRS21ReservationMapper.cs
│   ├── GoogleReservationDTOMapper.cs
│   ├── GoogleReservationMapper.cs
│   ├── GoogleRoomMapper.cs
│   ├── GoogleRoomDTOMapper.cs
│   ├── DIRS21RoomDTOMapper.cs
│   ├── DIRS21RoomMapper.cs
├── Services
│   ├── MapHandler.cs
├── ReadFile
│   ├── ReadFromFiles.cs
├── Exceptions
│   ├── InvalidMappingException.cs
│   ├── MappingValidationException.cs
├── Tests
│   ├── DIRS21RoomMapperTest.cs
│   ├── DIRS21ReservationMapperTest.cs
│   ├── GoogleReservationMapperTest.cs
│   ├── GoogleRoomMapperTest.cs
└── Program.cs

How It Works:
The system dynamically maps data between different models using mappers. Here’s how the system flows:

Internal Model to DTO: The first step in many mappings is transforming an internal model (like Room) to a DTO.
DTO to External Model: The second step maps the DTO to an external system’s model (like GoogleRoom).

Example Mapping Flow:
Room (DIRS21) → RoomDTO → GoogleRoom (Google)
By using the MapperFactory, the system dynamically selects the correct mappers based on the source and target models. If no mapper is found for the provided types, an exception is thrown.

Key Features:
Dynamic Mappings: Easily add new mappers without modifying existing code. 
DTO as Decoupling Layer: The use of DTOs ensures that the internal and external models remain decoupled, allowing the system to adapt to future changes more easily.

Error Handling: Custom exceptions (InvalidMappingException, MappingValidationException) are used to handle errors gracefully.

Modify Mappings:
To add a new mapping between internal and external models:

Create a new mapper class (e.g., RoomDTOToBookingRoomMapper).
Implement the IModelMapper interface.
Register the mapper in MapperFactory.

Error Handling:
If a mapping fails (e.g., no mapper is found or the input model is invalid), you will see an error message, and the exception will be logged if logging is enabled.

Logging:
This system includes Serilog for logging. The logs are written both to the console and to a file located in the logs folder. You can configure the logging behavior in Program.cs.

Known Issues:
Unmapped Models: If a specific mapping is not registered in the MapperFactory, an InvalidMappingException will be thrown.

Null Values: Ensure that models passed into the MapHandler are valid and fully populated.
Future Enhancements:
Support for Additional External Systems: You can add new partners (e.g., Booking.com, Expedia) by creating new mappers for their respective models.

Validation Logic: Add more complex validation mechanisms before performing mappings.

Contact:
For any questions or issues, feel free to contact [anirban.ghosh1512@gmail.com].
