using MVC.Models;
using System;
using System.Collections.Generic;

namespace MVC.Utils.DB
{
    internal interface IRepository<T> where T : BaseModel
    {
        List<T> FindAll();
        T FindOne(Guid id);
        T Add(T entity);
        T Update(Guid id, T entity);
        T Delete(Guid id);
    }
}
