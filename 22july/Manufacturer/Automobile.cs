using AutomobileApp.Models;
using System.ComponentModel.DataAnnotations;

namespace _22july_Manufacturing.Models
{
    public class Automobile
    {
        [Key]
        public int AutomobileId { get; set; }

        [Required(ErrorMessage = "Automobile Name is required.")]
        [StringLength(100)]
        [Display(Name = "Automobile Name")]
        public string AutomobileName { get; set; }

        [Required(ErrorMessage = "Registration Number is required.")]
        [StringLength(20)]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        // Foreign key link to the Manufacturer submitted in the same form
        public Manufacturer Manufacturer { get; set; }
    }
}
