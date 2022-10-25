using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static Library.Data.DataConstant.ApplicationUserConstant;
using static Library.Data.DataConstant.RegisterError;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxlength, MinimumLength = UserNameMinlength, ErrorMessage = UserNameError)]
        [DisplayName("User Name")]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxlength, MinimumLength = EmailMinlength, ErrorMessage = EmailNameError)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
