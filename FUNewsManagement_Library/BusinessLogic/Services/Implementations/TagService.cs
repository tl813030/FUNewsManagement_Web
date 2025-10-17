using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly TagRepository _repo;

        public TagService(TagRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Tag> GetAllTags() => _repo.GetAll();

        public Tag GetTagById(int id)
        {
            var tag = _repo.GetById(id);
            if (tag == null)
                throw new Exception("Tag not found.");
            return tag;
        }

        public void AddTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            if (string.IsNullOrWhiteSpace(tag.TagName))
                throw new Exception("Tag name cannot be empty.");

            _repo.Add(tag);
        }

        public void UpdateTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            if (string.IsNullOrWhiteSpace(tag.TagName))
                throw new Exception("Tag name cannot be empty.");

            _repo.Update(tag);
        }

        public void DeleteTag(int id)
        {
            try
            {
                _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot delete Tag: {ex.Message}");
            }
        }

        public IEnumerable<Tag> SearchTags(string keyword) => _repo.Search(keyword);

        public bool ExistsByName(string tagName) => _repo.ExistsByName(tagName);
    }
}
