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
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly FunewsManagementContext _context;
        public SystemAccountRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<SystemAccount> GetAll()
        {
            return _context.SystemAccounts.OrderBy(a => a.AccountName).ToList();
        }

        public SystemAccount GetById(short id)
        {
            return _context.SystemAccounts.FirstOrDefault(a => a.AccountId == id);
        }

        public SystemAccount GetByEmail(string email)
        {
            return _context.SystemAccounts.FirstOrDefault(a => a.AccountEmail == email);
        }

        public void Add(SystemAccount account)
        {
            if (ExistsByEmail(account.AccountEmail))
                throw new Exception("Email already exists.");
            _context.SystemAccounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(SystemAccount account)
        {
            var existing = _context.SystemAccounts.FirstOrDefault(a => a.AccountId == account.AccountId);
            if (existing == null) throw new Exception("Account not found.");

            if (ExistsByEmail(account.AccountEmail) && existing.AccountEmail != account.AccountEmail)
                throw new Exception("Email already exists.");

            existing.AccountName = account.AccountName;
            existing.AccountEmail = account.AccountEmail;
            existing.AccountPassword = account.AccountPassword;
            existing.AccountRole = account.AccountRole;

            _context.SaveChanges();
        }

        public void Delete(short id)
        {
            var account = _context.SystemAccounts.FirstOrDefault(a => a.AccountId == id);
            if (account == null) return;

            // kiểm tra nếu account này đã tạo bài viết thì không cho xóa
            bool inUse = _context.NewsArticles.Any(n => n.CreatedById == id);
            if (inUse)
                throw new Exception("Cannot delete account because it created some articles.");

            _context.SystemAccounts.Remove(account);
            _context.SaveChanges();
        }

        public bool ExistsByEmail(string email)
        {
            return _context.SystemAccounts.Any(a => a.AccountEmail.ToLower() == email.ToLower());
        }

        public IEnumerable<SystemAccount> Search(string keyword)
        {
            keyword = keyword?.Trim().ToLower() ?? "";
            return _context.SystemAccounts
                .Where(a =>
                    (a.AccountName != null && a.AccountName.ToLower().Contains(keyword)) ||
                    (a.AccountEmail != null && a.AccountEmail.ToLower().Contains(keyword)))
                .OrderBy(a => a.AccountName)
                .ToList();
        }
    }
}
