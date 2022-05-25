using Data.Dictionary;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLRepository
{
    public class SQLDictionary : IPhoneDictionary<User>
    {
        private PhoneBookContext _dbContext;

        public SQLDictionary()
        {
            _dbContext = new PhoneBookContext();
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
            if (user != null)
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
            return _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User Update(Guid id, User entity)
        {
            var user = _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Name = entity.Name;
                user.Number = entity.Number;
                _dbContext.SaveChanges();
            }
            return user;
        }
    }
}
