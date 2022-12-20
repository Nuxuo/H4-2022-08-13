using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Entry_SensorDataDto {
        public int SensorId {get; set;}
        public float Data {get; set;}
    }
}   