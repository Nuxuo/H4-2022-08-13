using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class HubSensorsDto : BaseDto{
        public string Name {get; set;}
        public int SensorId {get; set;}
        public int PortTypeId {get; set;}
        public bool Disabled {get; set;}
        public int Port {get; set;}
    }
}