using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Expanded_DataPackageDto{
        public DateTime CreatedDate {get; set;}
        public ICollection<SensorDataDto> SensorData {get; set;}
    }
}   