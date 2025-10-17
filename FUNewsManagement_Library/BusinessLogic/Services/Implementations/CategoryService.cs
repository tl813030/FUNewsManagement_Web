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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo) { _repo = repo; }

        public IEnumerable<Category> GetAll() => _repo.GetAll();
        public Category? GetById(short id) => _repo.GetById(id);

        public void Create(Category entity)
        {
            entity.IsActive = true;
            _repo.Add(entity);
        }

        public void Update(Category entity) => _repo.Update(entity);
        public void Delete(short id)
        {
            var cat = _repo.GetById(id);
            if (cat != null) _repo.Delete(cat);
        }
    }
}
