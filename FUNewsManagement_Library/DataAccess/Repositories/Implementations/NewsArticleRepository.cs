using DataAccess.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly FunewsManagementContext _context;
        public NewsArticleRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<NewsArticle> GetAll() =>
            _context.NewsArticles.Include(n => n.Category).Include(n => n.CreatedBy).Include(n => n.Tags).ToList();

        public NewsArticle? GetById(string id) =>
            _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.CreatedBy)
                .Include(n => n.Tags)
                .FirstOrDefault(n => n.NewsArticleId == id);
        

        public void Add(NewsArticle entity)
        {
            _context.NewsArticles.Add(entity);
            _context.SaveChanges();
        }

        public void Update(NewsArticle entity)
        {
            _context.NewsArticles.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(NewsArticle entity)
        {
            _context.NewsArticles.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<NewsArticle> Search(string keyword)
        {
            return _context.NewsArticles
                .Include(n => n.Category)
                .Where(n => n.NewsTitle!.Contains(keyword) || n.Headline.Contains(keyword) || n.Category.CategoryName.Contains(keyword))
                .ToList();
        }
    }
}
