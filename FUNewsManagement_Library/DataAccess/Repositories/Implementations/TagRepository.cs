using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly FunewsManagementContext _context;
        public TagRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.OrderBy(t => t.TagName).ToList();
        }

        public Tag GetById(int id)
        {
            return _context.Tags.FirstOrDefault(t => t.TagId == id);
        }

        public void Add(Tag tag)
        {
            if (ExistsByName(tag.TagName))
                throw new Exception("Tag name already exists.");
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void Update(Tag tag)
        {
            var existing = _context.Tags.FirstOrDefault(t => t.TagId == tag.TagId);
            if (existing == null) throw new Exception("Tag not found.");

            if (ExistsByName(tag.TagName) && existing.TagName != tag.TagName)
                throw new Exception("Tag name already exists.");

            existing.TagName = tag.TagName;
            existing.Note = tag.Note;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.TagId == id);
            if (tag == null) return;

            // kiểm tra xem có bài viết nào đang dùng tag này không
            if (tag.NewsArticles != null && tag.NewsArticles.Any())
            {
                throw new Exception("Cannot delete Tag because it is used in one or more NewsArticles.");
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }

        public IEnumerable<Tag> Search(string keyword)
        {
            keyword = keyword?.Trim().ToLower() ?? "";
            return _context.Tags
                .Where(t => t.TagName.ToLower().Contains(keyword)
                         || (t.Note != null && t.Note.ToLower().Contains(keyword)))
                .OrderBy(t => t.TagName)
                .ToList();
        }

        public bool ExistsByName(string tagName)
        {
            return _context.Tags.Any(t => t.TagName.ToLower() == tagName.ToLower());
        }
    }
}
