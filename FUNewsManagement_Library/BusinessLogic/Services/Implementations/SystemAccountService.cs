using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly SystemAccountRepository _repo;

        public SystemAccountService(SystemAccountRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<SystemAccount> GetAllAccounts() => _repo.GetAll();

        public SystemAccount GetAccountById(short id)
        {
            var acc = _repo.GetById(id);
            if (acc == null)
                throw new Exception("Account not found.");
            return acc;
        }

        public SystemAccount GetAccountByEmail(string email)
        {
            var acc = _repo.GetByEmail(email);
            if (acc == null)
                throw new Exception("Account not found with given email.");
            return acc;
        }

        public void AddAccount(SystemAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            if (string.IsNullOrWhiteSpace(account.AccountEmail))
                throw new Exception("Email cannot be empty.");

            if (_repo.ExistsByEmail(account.AccountEmail))
                throw new Exception("Email already exists.");

            _repo.Add(account);
        }

        public void UpdateAccount(SystemAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            if (string.IsNullOrWhiteSpace(account.AccountEmail))
                throw new Exception("Email cannot be empty.");

            _repo.Update(account);
        }

        public void DeleteAccount(short id)
        {
            try
            {
                _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot delete account: {ex.Message}");
            }
        }

        public bool ExistsByEmail(string email) => _repo.ExistsByEmail(email);

        public IEnumerable<SystemAccount> SearchAccounts(string keyword) => _repo.Search(keyword);
    }

}
