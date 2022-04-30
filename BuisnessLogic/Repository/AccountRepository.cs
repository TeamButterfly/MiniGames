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
        private readonly DatabaseContext _dbContext;

        public AccountRepository(IDatabaseConnection connection, bool isTest = false)
        {
            _dbContext = (isTest ? connection.TestDatabaseContext : connection.DatabaseContext);
        }

        public Account GetAccount(Guid id)
        {
            return _dbContext.Accounts
                .Where(a => a.AccountId.Equals(id))
                .Include(a => a.User)
                .First();
        }

        public Account GetAccountByUserId(Guid id)
        {
            return _dbContext.Accounts
                .Where(a => a.UserId.Equals(id))
                .Include(a => a.User)
                .First();
        }

        public List<Account> GetAccounts()
        {
            return _dbContext.Accounts
                .Include(a => a.User)
                .ToList();
        }

        public bool UpdateAccount(Account accountModel)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(accountModel.AccountId));
            if (account == null)
            {
                var newAccount = new Account { AccountId = Guid.NewGuid(), Points = accountModel.Points, UserId = accountModel.UserId };
                _dbContext.Accounts.Add(newAccount);
                _dbContext.SaveChanges();
                return true;
            }

            account.Points = accountModel.Points;

            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAccount(Guid id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(id));
            if (account == null)
            {
                throw new Exception("Kontoen eksisterer ikke");
            }

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
