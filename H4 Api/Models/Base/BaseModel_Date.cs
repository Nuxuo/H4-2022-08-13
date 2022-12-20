using System.ComponentModel.DataAnnotations;

namespace Models{
    public class BaseModel_Date : BaseModel{
        
        public DateTime CreatedDate {get; set;}

        public BaseModel_Date(){
            CreatedDate = DateTime.Now;
        }
    }
}