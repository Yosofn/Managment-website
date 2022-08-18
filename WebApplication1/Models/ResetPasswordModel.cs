using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class ResetPasswordModel
    {

        [Required(ErrorMessage ="Password is required")]

        [MinLength(5, ErrorMessage="Minimum Password is 5")]


          public string Password { get; set; }
        
        [Required(ErrorMessage ="Confirmed Password is required")]
        [MinLength (5, ErrorMessage="Minimum Length is 5")]
        [Compare ("Password", ErrorMessage="Password no match")]
        public string ConfirmPassword { get; set; } 

        public string Email { get; set; }

        public string Token { get; set; }  
    }
}
