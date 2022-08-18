using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email Adresse is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Minimum length is 8")]
        public string Password { get; set; }
     

        public bool RememberMe { get; set; }
    }
}
