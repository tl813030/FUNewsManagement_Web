using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(int id);
        IEnumerable<Tag> Search(string keyword);
        bool ExistsByName(string tagName); // kiểm tra trùng tên
    }
}
