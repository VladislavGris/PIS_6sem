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
            entity.Id = Guid.NewGuid();
            var user = _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return user;
        }

        public User Delete(Guid id)
        {
            var user = _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
            if(user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            return user;
        }

        public List<User> FindAll()
        {
            return _dbContext.Users.ToList();
        }

        public User FindOne(Guid id)
        {
            return _dbContext.Users.Where(u=>u.Id == id).FirstOrDefault();
        }

        public User Update(Guid id, User entity)
        {
            var user = _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
            if(user != null)
            {
                user.Name = entity.Name;
                user.Number = entity.Number;
                _dbContext.SaveChanges();
            }
            return user;
        }
    }
}