using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FunewsManagementContext _context;
        public CategoryRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll() => _context.Categories.Include(c => c.ParentCategory).ToList();
        public Category? GetById(short id) => _context.Categories.Find(id);
        public void Add(Category entity) { _context.Categories.Add(entity); _context.SaveChanges(); }
        public void Update(Category entity) { _context.Categories.Update(entity); _context.SaveChanges(); }
        public void Delete(Category entity) { _context.Categories.Remove(entity); _context.SaveChanges(); }
    }
}
