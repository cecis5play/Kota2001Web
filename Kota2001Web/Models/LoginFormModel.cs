using System.ComponentModel.DataAnnotations;

namespace Kota2001Web.Models
{
    public class LoginFormModel
    {
        [EmailAddress(ErrorMessage = "Email адресът ви трябва да е в правилен формат")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Това поле е задължително")]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
