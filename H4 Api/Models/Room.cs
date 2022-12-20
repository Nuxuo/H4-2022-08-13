using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class Room : BaseModel{
        [MaxLength(50)]
        public string Name {get; set;}
        public int BuildingId {get; set;}
        [ForeignKey("BuildingId")]
        public Building Building {get; set;}

        public ICollection<Hub> Hubs {get; set;}


    }
}