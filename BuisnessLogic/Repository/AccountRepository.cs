using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(Guid id)
        {
            using var _dbContext = new DatabaseContext();
            return _dbContext.Accounts
                .Where(a => a.AccountId.Equals(id))
                .Include(a => a.User)
                .First();
        }

        public Account GetAccountByUserId(Guid id)
        {
            using var _dbContext = new DatabaseContext();
            return _dbContext.Accounts
                .Where(a => a.UserId.Equals(id))
                .Include(a => a.User)
                .First();
        }

        public List<Account> GetAccounts()
        {
            using var _dbContext = new DatabaseContext();
            return _dbContext.Accounts
                .Include(a => a.User)
                .ToList();
        }

        public bool UpdateAccount(Account accountModel)
        {
            using var _dbContext = new DatabaseContext();

            var account = _dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(accountModel.UserId));
            if (account == null)
            {
                throw new Exception("Kontoen eksisterer ikke");
            }

            account.Points = accountModel.Points;

            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
