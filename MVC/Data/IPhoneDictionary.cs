using Data.Models;
using System;
using System.Collections.Generic;

namespace Data.Dictionary
{
    public interface IPhoneDictionary<T> where T : BaseModel
    {
        List<T> FindAll();
        T FindOne(Guid id);
        T Add(T entity);
        T Update(Guid id, T entity);
        T Delete(Guid id);
    }
}