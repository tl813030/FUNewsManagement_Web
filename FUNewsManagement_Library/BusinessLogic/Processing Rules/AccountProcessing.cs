using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Không xóa admin cuối cùng, kiểm tra bài viết đã tạo
namespace BusinessLogic.Processing_Rules
{
    public class AccountProcessing
    {
        private readonly ISystemAccountService _accountService;
        private readonly INewsArticleService _newsService;

        public AccountProcessing(ISystemAccountService accountService, INewsArticleService newsService)
        {
            _accountService = accountService;
            _newsService = newsService;
        }

        // Không được xóa tài khoản nếu đã đăng bài
        public void ValidateBeforeDelete(short accountId)
        {
            var articles = _newsService.GetArticlesByAuthor(accountId);
            if (articles.Any())
                throw new Exception("Cannot delete this account because it created articles.");
        }

        // Không được xóa admin cuối cùng
        public void ValidateDeleteAdmin(short accountId)
        {
            var acc = _accountService.GetAccountById(accountId);
            if (acc.AccountRole == 1) // Admin
            {
                var allAdmins = _accountService.GetAllAccounts().Where(a => a.AccountRole == 1);
                if (allAdmins.Count() <= 1)
                    throw new Exception("Cannot delete the last admin account.");
            }
        }
    }
}
