using System.ComponentModel.DataAnnotations;

namespace Kota2001Web.Models
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = "Това поле е задължително")]
        [StringLength(50, MinimumLength = 2)]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Това поле е задължително")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Email адресът ви трябва да е в правилен формат")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Това поле е задължително")]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        [Required(ErrorMessage = "Това поле е задължително")]
        public string ConfirmPassword { get; set; }
        [Phone(ErrorMessage = "Телефонният ви номер трябва да е в правилен формат")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public string PhoneNumber { get; set; }
        
        public bool IsPersistent { get; set; }
    }
}
