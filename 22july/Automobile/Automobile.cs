using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace _22july_Automobile.Models
{
    public class Automobile
    {
        [Required(ErrorMessage ="Vehicle Id is Mandatory.")]
        [Range(100,1000, ErrorMessage = "Vehicle Id must be between 100 to 1000")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Vehicle Name is Mandatory.")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Vehicle Name must be at least 3 characters and at most of 20 characters.")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Vehicle Brand is Mandatory.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Vehicle Name must be at least 1 characters and at most of 20 characters.")]
        public string Brand { get; set; }


        [Required(ErrorMessage = "Vehicle Model Year is Mandatory.")]
        [Range(1947,2027)]
        public double Model_Year {  get; set; }


        [Required(ErrorMessage = "Vehicle Price is Mandatory.")]
        [Range(1000,100000000,ErrorMessage ="Price of the Vehicle must be between 1000 to 100000000.")]
        public double Price {  get; set; }


        [Required(ErrorMessage = "Vehicle Fuel Type is Mandatory.")]
        public string Fuel_Type {  get; set; }




    }
}
