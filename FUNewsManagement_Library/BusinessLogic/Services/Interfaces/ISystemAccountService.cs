using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ISystemAccountService
    {
        IEnumerable<SystemAccount> GetAllAccounts();
        SystemAccount GetAccountById(short id);
        SystemAccount GetAccountByEmail(string email);
        void AddAccount(SystemAccount account);
        void UpdateAccount(SystemAccount account);
        void DeleteAccount(short id);
        bool ExistsByEmail(string email);
        IEnumerable<SystemAccount> SearchAccounts(string keyword);
    }
}
