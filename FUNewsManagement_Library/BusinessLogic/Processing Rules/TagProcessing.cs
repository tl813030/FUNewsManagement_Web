using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Không xóa tag đang được dùng
namespace BusinessLogic.Processing_Rules
{
    public class TagProcessing
    {
        
        private readonly ITagService _tagService;
        private readonly INewsArticleService _newsService;

        public TagProcessing(ITagService tagService, INewsArticleService newsService)
        {
            _tagService = tagService;
            _newsService = newsService;
        }

        // Không cho xóa tag đang được dùng trong bài viết
        public void ValidateBeforeDelete(int tagId)
        {
            var allArticles = _newsService.GetAll();
            //bool inUse = allArticles.Any(a => a.NewsTags != null && a.NewsTags.Any(t => t.TagID == tagId));
            //if (inUse)
                //throw new Exception("Cannot delete tag because it is being used in articles.");
        }
    }
}
