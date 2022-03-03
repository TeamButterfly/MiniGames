using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Repository
{
    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public List<User> GetUsers();
        public User GetUser(Guid id);
    }
}