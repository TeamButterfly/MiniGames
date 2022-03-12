using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Repository
{
    public interface IAccountRepository
    {
        public bool UpdateAccount(Account account);
        public List<Account> GetAccounts();
        public Account GetAccount(Guid id);
        public Account GetAccountByUserId(Guid id);
        public bool DeleteAccount(Guid id);
    }
}