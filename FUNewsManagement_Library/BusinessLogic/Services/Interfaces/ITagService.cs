using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        void AddTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(int id);
        IEnumerable<Tag> SearchTags(string keyword);
        bool ExistsByName(string tagName);
    }
}
