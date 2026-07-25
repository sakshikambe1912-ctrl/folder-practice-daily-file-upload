using System.ComponentModel.DataAnnotations;

namespace _21julyemployee.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Employee Id is Manadatory.")]
        [Range(0,100)]
        public double employee_id {  get; set; }

        [Required(ErrorMessage = "Employee Name is Manadatory.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name of Employee must have at least 3 characters and maximum of 20 letters")]
        public string employee_name {  get; set; }

        [Required(ErrorMessage ="Department of the Employee is Manadatory.")]
        public string department {  get; set; }

        [Required(ErrorMessage ="Employee salary is Manadatory.")]
        [Range(100,1000000,ErrorMessage ="Salary must be between 100 to 100000")]
        public double salary { get; set; }

        [Required(ErrorMessage ="Employee email is Manadatory.")]
        [EmailAddress(ErrorMessage ="Invalid Email,Please enter the correct Email Address.")]
        public string email { get; set; }

    }
}
