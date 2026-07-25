using System.ComponentModel.DataAnnotations;

namespace _23july_Stationary.Models
{
    public class Login
    {

        [Required(ErrorMessage ="Username is Mandatory.")]
        public string Username {  get; set; }
        [Required(ErrorMessage = "Password is Mandatory.")]
        public string Password { get; set; }
    }
}
