using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Utils.DB
{
    public class SqlUserRepository : IRepository<User>
    {
        private PhoneBookContext _dbContext;
        private static SqlUserRepository _userRepo;

        private SqlUserRepository()
        {
            _dbContext = new PhoneBookContext();
        }

        public static SqlUserRepository GetInstance()
        {
            if (_userRepo == null)
            {
                _userRepo = new SqlUserRepository();
            }
            return _userRepo;
        }

        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public User Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            return _dbContext.Users.ToList();
        }

        public User FindOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Update(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}