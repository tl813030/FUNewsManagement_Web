using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Kiểm tra trước khi xóa category
namespace BusinessLogic.Processing_Rules
{
    public class CategoryProcessing
    {
        private readonly INewsArticleService _newsService;

        public CategoryProcessing(INewsArticleService newsService)
        {
            _newsService = newsService;
        }

        // Không cho xóa chuyên mục đang có bài viết
        public void ValidateBeforeDelete(short categoryId)
        {
            var articles = _newsService.GetArticlesByCategory(categoryId);
            if (articles.Any())
                throw new Exception("Cannot delete category that contains articles.");
        }
    }
}
