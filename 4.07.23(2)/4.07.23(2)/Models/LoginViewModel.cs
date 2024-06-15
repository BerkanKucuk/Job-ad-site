using System.ComponentModel.DataAnnotations;

namespace _4._07._23_2_.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
