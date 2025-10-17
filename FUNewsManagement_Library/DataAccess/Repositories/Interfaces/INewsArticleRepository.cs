using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface INewsArticleRepository
    {
        IEnumerable<NewsArticle> GetAll();
        NewsArticle? GetById(string id);
        void Add(NewsArticle entity);
        void Update(NewsArticle entity);
        void Delete(NewsArticle entity);
        IEnumerable<NewsArticle> Search(string keyword);

    }
}
