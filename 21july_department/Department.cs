using System.ComponentModel.DataAnnotations;

namespace _21july_department.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(50)]
        public string DepartmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department Head is required")]
        [StringLength(50)]
        public string DepartmentHead { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter a valid 10-digit number")]
        public string HeadContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Head Email is required")]
        [EmailAddress]
        public string HeadEmail { get; set; } = string.Empty;
    }
}
