using System.ComponentModel.DataAnnotations;

namespace Models{
    public class Building : BaseModel{
        [MaxLength(50)]
        public string Name {get; set;}
        
        [MaxLength(100)]
        public string Address {get; set;}
        public ICollection<Room> Rooms {get; set;}
    }
}