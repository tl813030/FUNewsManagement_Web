using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Publish, validate quyền, xóa bài
namespace BusinessLogic.Processing_Rules
{
    public class NewsArticleProcessing
    {
        private readonly INewsArticleService _newsService;
        private readonly ISystemAccountService _accountService;
        private readonly ICategoryService _categoryService;

        public NewsArticleProcessing(
            INewsArticleService newsService,
            ISystemAccountService accountService,
            ICategoryService categoryService)
        {
            _newsService = newsService;
            _accountService = accountService;
            _categoryService = categoryService;
        }

        // 1.Chỉ Admin/Editor mới được đăng bài
        public void ValidatePublishPermission(short createdById)
        {
            var acc = _accountService.GetAccountById(createdById);
            if (acc == null) throw new Exception("Account not found.");

            if (acc.AccountRole != 1 && acc.AccountRole != 2)
                throw new Exception("Only Admin or Editor can publish articles.");
        }

        // 2.Khi publish bài viết
        public void PublishArticle(NewsArticle article)
        {
            ValidatePublishPermission(article.CreatedById ?? 0);
            article.NewsStatus = true;
            article.CreatedDate = DateTime.Now;
            _newsService.Update(article);
        }

        // 3️.Khi xóa bài: không được xóa bài đã publish
        public void ValidateBeforeDelete(NewsArticle article)
        {
            if (article.NewsStatus == true)
                throw new Exception("Cannot delete published article.");
        }

        // 4.Kiểm tra chuyên mục hợp lệ
        public void ValidateCategory(short categoryId)
        {
            var cat = _categoryService.GetById(categoryId);
            if (cat == null)
                throw new Exception("Invalid category selected.");
        }
    }
}
