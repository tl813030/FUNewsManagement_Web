using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class ProfileViewModel
    {
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [StringLength(100)]
        public string AccountEmail { get; set; }

        [StringLength(50)]
        public string? CurrentPassword { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%&?]).{6,}$",
    ErrorMessage = "Password must contain at least one letter, one number, and one special character (!@#$%&?)")]
        public string? NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        public int? AccountRole { get; set; }
        public string RoleName => AccountRole == 1 ? "Staff" : "Lecturer";
        public int NewsCount { get; set; }
    }
}
