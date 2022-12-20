using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class PortType : BaseModel{
        [MaxLength(50)]
        public string Type {get; set;}
    }
}