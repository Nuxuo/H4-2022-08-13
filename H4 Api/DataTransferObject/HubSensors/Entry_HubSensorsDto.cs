using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Entry_HubSensorsDto {
        public int HubId {get; set;}
        public int SensorId {get; set;}
        public bool Disabled {get; set;}
        public int Port {get; set;}
    }
}