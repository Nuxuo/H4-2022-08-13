using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class SensorDataDto{
        public int SensorId {get; set;}        
        public float Data {get; set;}
    }
}   