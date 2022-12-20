using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Entry_HubDto {
        public int RoomId {get; set;}
        public List<Entry_HubSensorsDto> Sensors {get;set;}
    }
}