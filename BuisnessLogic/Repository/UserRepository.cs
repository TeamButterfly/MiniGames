using BCryptNet = BCrypt.Net.BCrypt;

namespace BuisnessLogic.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(IDatabaseConnection connection, bool isTest = false)
        {
            _dbContext = (isTest ? connection.TestDatabaseContext : connection.DatabaseContext);
        }

        public User GetUser(Guid id)
        {
            return _dbContext.Users.First(u => u.UserId.Equals(id));
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public bool CreateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
                throw new Exception("En bruger med det brugername eksisterer allerede");

            if (user.UserId == Guid.Empty)
                user.UserId = Guid.NewGuid();

            ValidateUser(user);

            user.Password = BCryptNet.HashPassword(user.Password);

            _dbContext.Users.Add(user);
            var account = new Account { AccountId = Guid.NewGuid(), Points = 1, UserId = user.UserId };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateUser(User userModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId.Equals(userModel.UserId));
            if (user == null)
            {
                throw new Exception("Brugeren eksisterer ikke");
            }

            user.Username = userModel.Username;

            ValidateUser(user);

            if (userModel.Password != null)
                user.Password = BCryptNet.HashPassword(userModel.Password);

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId.Equals(id));
            if (user == null)
            {
                throw new Exception("Kontoen eksisterer ikke");
            }

            var account = _dbContext.Accounts.FirstOrDefault(a => a.UserId.Equals(id));

            _dbContext.Users.Remove(user);
            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
            return true;
        }
        public bool DeleteUsers(List<Guid> userIds)
        {
            var users = _dbContext.Users.Where(u => userIds.Contains(u.UserId)).ToList();
            var accounts = _dbContext.Accounts.Where(a => userIds.Contains(a.UserId)).ToList();

            _dbContext.Users.RemoveRange(users);
            _dbContext.Accounts.RemoveRange(accounts);
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