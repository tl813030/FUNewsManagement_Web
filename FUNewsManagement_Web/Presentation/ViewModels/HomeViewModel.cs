using DataAccess.Entities;

namespace Presentation.ViewModels
{
    public class HomeViewModel
    {
        public List<NewsArticle> FeaturedNews { get; set; }
        public List<Category> Categories { get; set; }
    }
}
