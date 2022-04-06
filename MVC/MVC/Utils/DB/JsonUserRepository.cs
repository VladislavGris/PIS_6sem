using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVC.Utils.DB
{
    public class JsonUserRepository : IRepository<User>
    {
        private List<User> _data = new List<User>();
        private static string _filepath = @"G:\\6_Sem\\RIS\\Labs\\database.json";
        private static JsonUserRepository _db;

        private JsonUserRepository()
        {
            if(!File.Exists(_filepath))
            {
                using (StreamWriter sw = File.CreateText(_filepath))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(_data));
                }
            }
            else
            {
                using (StreamReader r = new StreamReader(_filepath))
                {
                    string json = r.ReadToEnd();
                    _data = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }

        }

        public static JsonUserRepository GetInstance()
        {
            if(_db == null)
            {
                _db = new JsonUserRepository();
            }
            return _db;
        }

        public User Add(User entity)
        {
            entity.Id = Guid.NewGuid();
            _data.Add(entity);
            Save();
            return entity;
        }

        public User Delete(Guid id)
        {
            User userToDelete = _data.FirstOrDefault(x => x.Id == id);
            if(userToDelete != null)
            {
                _data.Remove(userToDelete);
                Save();
            }
            return userToDelete;
        }

        public List<User> FindAll()
        {
            return _data.OrderBy(i=>i.Name).ToList();
        }

        public User FindOne(Guid id)
        {
            return _data.FirstOrDefault(i => i.Id == id);
        }

        public User Update(Guid id, User entity)
        {
            User userToUpdate = _data.FirstOrDefault(x => x.Id == id);
            if(userToUpdate!=null)
            {
                userToUpdate.Name = entity.Name;
                userToUpdate.Number = entity.Number;
                Save();
            }
            return userToUpdate;
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(_filepath, false))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_data));
            }
        }
    }
}