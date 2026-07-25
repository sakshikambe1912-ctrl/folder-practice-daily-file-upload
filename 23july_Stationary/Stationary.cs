using System.ComponentModel.DataAnnotations;

namespace _23july_Stationary.Models
{
    public class Stationary
    {
        [Required(ErrorMessage ="Item Id is Mandatory.")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Item Name is Mandatory.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Item Stock is Mandatory.")]
        public double Stock {  get; set; }
    }
}
