using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace SmartTeapotsWebProject.Data.Models
{
    public class SignUp
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SurName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 6)]
        public string Email { get; set; }
    }

    public class SignIn
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

    }

    public class UProfile
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Login { get; set; }

        [Display(Name = "Old password")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "New password")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords don't match!")]
        public string ConfirmNewPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SurName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 6)]
        public string Email { get; set; }
        

    }
}