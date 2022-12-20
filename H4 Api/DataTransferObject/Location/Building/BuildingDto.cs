using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class BuildingDto : BaseDto{
        public string Name {get; set;}
        public string Address {get; set;}
    }
}