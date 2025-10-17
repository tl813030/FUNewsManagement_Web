using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category? GetById(short id);
        void Create(Category entity);
        void Update(Category entity);
        void Delete(short id);
    }
}
