using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class DataPackage : BaseModel_Date{
        public int HubId {get; set;}
        [ForeignKey("HubId")]
        public Hub Hub {get; set;}

        public ICollection<SensorData> SensorData {get; set;}
    }
}