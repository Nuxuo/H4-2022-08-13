using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Entry_DataPackageDto {
        public int HubId {get; set;}
        public List<Entry_SensorDataDto> SensorData {get; set;}
    }
}   