using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class DataPackageDto : BaseDto{
        public int HubId {get; set;}
        public DateTime CreatedDate {get; set;}
    }
}   