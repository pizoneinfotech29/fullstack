using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace fullStackTask.Models
{
    public class RegistrationForm
    {
       
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone_no { get; set; } = string.Empty;
        //public int Age { get; set; } 

        public DateTime Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public string Occupation { get; set; } = string.Empty;

        public int Experience { get; set; } 
        public int CTC { get; set; } 
        public int No_of_employee { get; set; } 
        public string Type { get; set; } = string.Empty;


    }
}
