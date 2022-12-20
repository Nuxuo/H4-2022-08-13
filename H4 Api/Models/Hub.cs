using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class Hub : BaseModel_Date{
        public int RoomId {get; set;}
        [ForeignKey("RoomId")]
        public Room Room {get; set;}
        public bool SoftDeleted {get; set;}

        public ICollection<HubSensors> HubSensors {get; set;}
        public ICollection<DataPackage> DataPackages {get; set;}

        public Hub(){
            SoftDeleted = false;
        }
    }
}