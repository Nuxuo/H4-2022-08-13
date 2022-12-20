using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class Expanded_HubDto : BaseDto{
        public int RoomId {get; set;}
        public DateTime CreatedDate {get; set;}
        public bool SoftDeleted {get; set;}
    }
}   