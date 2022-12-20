using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class HubSensors : BaseModel{
        public int HubId {get; set;}
        [ForeignKey("HubId")]
        public Hub Hub {get; set;}

        public int SensorId {get; set;}
        [ForeignKey("SensorId")]
        public Sensor Sensor {get; set;}
        
        public bool Disabled {get; set;}
        public int Port {get; set;}

    }
}