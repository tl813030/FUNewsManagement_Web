using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface INewsArticleService
    {
        IEnumerable<NewsArticle> GetAll();
        NewsArticle? GetById(string id);
        void Create(NewsArticle entity);
        void Update(NewsArticle entity);
        void Delete(string id);
        IEnumerable<NewsArticle> Search(string keyword);
        IEnumerable<NewsArticle> GetArticlesByCategory(short categoryId);
        IEnumerable<NewsArticle> GetArticlesByAuthor(short accountId);
        IEnumerable<NewsArticle> GetPublishedArticles();
        IEnumerable<NewsArticle> GetUnpublishedArticles();
    }
}

