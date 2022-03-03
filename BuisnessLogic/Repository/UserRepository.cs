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
            return _dbContext.Users.First(u => u.UserId.Equals(id));
        }

        public List<User> GetUsers()
        {
            using var _dbContext = new DatabaseContext();
            return _dbContext.Users.ToList();
        }

        public bool CreateUser(User user)
        {
            if (user.UserId != Guid.Empty)
                throw new Exception("Et bruger id skal ikke sendes med ved oprettelse af bruger");

            using var _dbContext = new DatabaseContext();

            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
                throw new Exception("En bruger med det brugername eksisterer allerede");

            user.UserId = Guid.NewGuid();
            ValidateUser(user);

            _dbContext.Users.Add(user);
            var account = new Account { AccountId = Guid.NewGuid(), Points = 1, UserId = user.UserId };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateUser(User userModel)
        {
            using var _dbContext = new DatabaseContext();

            var user = _dbContext.Users.FirstOrDefault(u => u.UserId.Equals(userModel.UserId));
            if (user == null)
            {
                throw new Exception("Brugeren eksisterer ikke");
            }

            user.Username = userModel.Username;

            if(userModel.Password != null)
                user.Password = userModel.Password;

            ValidateUser(user);

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool ValidateUser(User user)
        {
            if (user.Username.Length < 3 || user.Username.Length > 20)
            {
                throw new Exception("Brugernavnet skal være mellem 3 og 20 karakterer");
            }
            if (user.Password.Length < 3 || user.Password.Length > 20)
            {
                throw new Exception("Passwordet skal være mellem 3 og 20 karakterer");
            }
            return true;
        }
    }
}