using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, ErrorMessage = "Category name must be under 100 characters")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category description is required")]
        [StringLength(500, ErrorMessage = "Category description must be under 500 characters")]
        public string CategoryDescription { get; set; }
        public int? ParentCategoryID { get; set; }
        public bool IsActive { get; set; }
        public string? ParentCategoryName { get; set; }
        public int NewsCount { get; set; }
    }
}

