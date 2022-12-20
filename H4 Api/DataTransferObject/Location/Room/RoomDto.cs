using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class RoomDto : BaseDto{
        public string Name {get; set;}
        public int BuildingId {get; set;}
    }
}