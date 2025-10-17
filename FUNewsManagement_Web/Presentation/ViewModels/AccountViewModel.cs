using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class AccountViewModel
    {
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [StringLength(100)]
        public string AccountEmail { get; set; }

        public int? AccountRole { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%&?]).{6,}$",
    ErrorMessage = "Password must contain at least one letter, one number, and one special character (!@#$%&?)")]
        public string? AccountPassword { get; set; }
    }
}
