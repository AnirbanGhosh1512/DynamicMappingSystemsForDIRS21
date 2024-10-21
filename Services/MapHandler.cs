using Dynamic_Mapping_System.Mappers;

namespace Dynamic_Mapping_System.Services
{
    public class MapHandler
    {
        private readonly Dictionary<string, IMapper> _mappers = new Dictionary<string, IMapper>();

        public MapHandler()
        {
            //For Reservation
            _mappers.Add("Google.Reservation", new GoogleReservationMapper());
            _mappers.Add("DTO.GoogleReservationDTO", new GoogleReservationDTOMapper());
            _mappers.Add("Model.Reservation", new DIRS21ReservationMapper());
            _mappers.Add("DTO.ReservationDTO", new DIRS21ReservationDTOMapper());

            //For Room
            _mappers.Add("Google.Room", new GoogleRoomMapper());
            _mappers.Add("DTO.GoogleRoomDTO", new GoogleRoomDTOMapper());
            _mappers.Add("Model.Room", new DIRS21RoomMapper());
            _mappers.Add("DTO.RoomDTO", new DIRS21RoomDTOMapper());
        }

        public object Map(object data, string sourceType, string targetType)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Data cannot be null.");

            if (_mappers.ContainsKey(sourceType))
            {
                return _mappers[sourceType].Map(data);
            }

            throw new InvalidOperationException($"Unsupported mapping from {sourceType} to {targetType}.");
        }
    }
}


