using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class ForgetViewModel
    {

        [Required(ErrorMessage = "Email Adresse is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

      
    }
}
