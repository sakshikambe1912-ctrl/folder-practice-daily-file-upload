using System.ComponentModel.DataAnnotations;

namespace _27julyProduct.Models
{
    public class Product
    {
        [Required(Error Message="Id of the product is required.")]
        [Range(3,100000,ErrorMessage ="the Id of product must lie between the 3 and 100000.")]
        public int Id {  get; set; }

        [Required(Error Message = "Name of product is required.")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Name must have maximum of 20 and minimum of 3 characters.")]
        public string Name { get; set; }

        [Required(Error Message = "Quantity of the product is required.")]
        public int Quantity { get; set; }

        [Required(Error Message = "Price of the product is required.")]
        public decimal Price { get; set; }



    }
}
