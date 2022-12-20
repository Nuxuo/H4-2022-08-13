using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class SensorData : BaseModel{
        public int SensorId {get; set;}        
        [ForeignKey("SensorId")]
        public Sensor Sensor {get; set;}
        public int DataPackageId {get; set;}
        [ForeignKey("DataPackageId")]
        public DataPackage DataPackage {get; set;}
        public float Data {get; set;}
    }
}