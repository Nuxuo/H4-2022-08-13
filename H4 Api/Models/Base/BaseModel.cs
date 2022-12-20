using System.ComponentModel.DataAnnotations;

namespace Models{
    public class BaseModel{
        [Key]
        [Required]
        public int Id {get; set;}
    }
}