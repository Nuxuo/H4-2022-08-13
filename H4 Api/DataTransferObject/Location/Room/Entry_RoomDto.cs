using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Entry_RoomDto{
        public string Name {get; set;}
        public int BuildingId {get; set;}
    }
}