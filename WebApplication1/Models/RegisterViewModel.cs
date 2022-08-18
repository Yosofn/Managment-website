using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage ="Email Adresse is required")]
        [EmailAddress(ErrorMessage ="Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8,ErrorMessage = "Minimum length is 8")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmedPassword is required")]
        [Compare("Password", ErrorMessage = "No Match ")]
        public string ConfirmedPassword { get; set; }

        public bool IsAgree { get; set; }



    }
}
