using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Expanded_HubSensorsDto : BaseDto{
        public int HubId {get; set;}
        public int SensorId {get; set;}
        public string Name {get; set;}
        public string DataType {get; set;}
        public string PortType {get; set;}
        public int Port {get; set;}
    }
}