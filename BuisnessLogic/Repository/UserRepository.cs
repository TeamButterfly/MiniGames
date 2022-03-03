using BuisnessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(Guid id)
        {
            using var _dbContext = new DatabaseContext();
            return _dbContext.Users.First(u => u.UserId == id);
        }

        public List<User> GetUsers()
        {
            using var _dbContext = new DatabaseContext();
            return _dbContext.Users.ToList();
        }

        public bool CreateUser(User user)
        {
            using var _dbContext = new DatabaseContext();

            if (user.UserId == Guid.Empty)
            {
                user.UserId = Guid.NewGuid();
            }
            else
            {
                throw new Exception("Et bruger id skal ikke sendes med ved oprettelse af bruger");
            }

            _dbContext.Users.Add(user);
            var account = new Account { AccountId = Guid.NewGuid(), Points = 1, UserId = user.UserId };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateUser(User userModel)
        {
            using var _dbContext = new DatabaseContext();

            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userModel.UserId);
            if (user == null)
            {
                throw new Exception("Brugeren eksisterer ikke");
            }

            user.Username = userModel.Username;

            if(userModel.Password != null)
                user.Password = userModel.Password;

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return true;
        }
    }
}