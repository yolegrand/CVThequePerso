using System;
using System.Collections.Generic;
using System.Text;

namespace DalHttp.core.Repositories
{
    public interface IRepository<TKey, T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(TKey Id);
        bool Create(T entity);
        bool Update(TKey Id, T entity);
        bool Delete(TKey Id);
    }
}
