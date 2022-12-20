using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class Sensor : BaseModel{
        [MaxLength(50)]
        public string Name {get; set;}
        
        [MaxLength(100)]
        public string DataType {get; set;}

        public int PortTypeId {get; set;}
        [ForeignKey("PortTypeId")]
        public PortType portType {get; set;}

        public ICollection<SensorData> SensorDatas {get; set;}
    }
}