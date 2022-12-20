using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class HubDto : BaseDto{
        public string Room {get; set;}
        public int RoomId {get; set;}
        public DateTime CreatedDate {get; set;}

        public List<HubSensorsDto> HubSensors {get; set;}

    }
}