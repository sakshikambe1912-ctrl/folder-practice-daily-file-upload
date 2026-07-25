using System;
using System.ComponentModel.DataAnnotations;

namespace AutomobileApp.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "Manufacturer Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Manufacturer Name must be between 2 and 100 characters.")]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Contact Number must be exactly 10 digits.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}