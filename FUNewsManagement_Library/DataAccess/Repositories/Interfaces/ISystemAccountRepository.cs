using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ISystemAccountRepository
    {
        IEnumerable<SystemAccount> GetAll();
        SystemAccount GetById(short id);
        SystemAccount GetByEmail(string email);
        void Add(SystemAccount account);
        void Update(SystemAccount account);
        void Delete(short id);
        bool ExistsByEmail(string email);
        IEnumerable<SystemAccount> Search(string keyword);
    }
}
