using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class chart_DataPackageDto{
        public string[] Sensor {get; set;}
        public List<List<object>> SensorData {get; set;}
    }
}   