using System.ComponentModel.DataAnnotations;

namespace _21july_department.Models
{
    public class Employee
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; } = string.Empty;

        // ...your other fields
    }
}
