using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _repo;

        public NewsArticleService(INewsArticleRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<NewsArticle> GetAll() => _repo.GetAll();

        public NewsArticle? GetById(string id) => _repo.GetById(id);

        public void Create(NewsArticle entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.NewsStatus = true;
            _repo.Add(entity);
        }

        public void Update(NewsArticle entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _repo.Update(entity);
        }

        public void Delete(string id)
        {
            var news = _repo.GetById(id);
            if (news != null) _repo.Delete(news);
        }

        public IEnumerable<NewsArticle> Search(string keyword) => _repo.Search(keyword);

        //Lấy danh sách bài viết theo Category
        public IEnumerable<NewsArticle> GetArticlesByCategory(short categoryId)
        {
            return _repo.GetAll().Where(a => a.CategoryId == categoryId);
        }
        //Lấy bài viết theo người tạo (Author)
        public IEnumerable<NewsArticle> GetArticlesByAuthor(short accountId)
        {
            return _repo.GetAll().Where(a => a.CreatedById == accountId);
        }

        //Lấy các bài viết đã publish
        public IEnumerable<NewsArticle> GetPublishedArticles()
        {
            return _repo.GetAll().Where(a => a.NewsStatus == true);
        }

        //Lấy các bài viết chưa publish
        public IEnumerable<NewsArticle> GetUnpublishedArticles()
        {
            return _repo.GetAll().Where(a => a.NewsStatus == false);
        }

    }
}
