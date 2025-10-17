using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class NewsArticleViewModel
    {
        public int NewsID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Display(Name = "Status")]
        public bool IsPublished { get; set; }
    }
}
