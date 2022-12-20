using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Id_Expanded_DataPackageDto : BaseDto{
        public DateTime CreatedDate {get; set;}
        public ICollection<SensorDataDto> SensorData {get; set;}
    }
}   