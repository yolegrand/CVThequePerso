using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface IRepository<TKey, T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(int Id);
        void Create(T entity);
        void Update(TKey id, T entity);
        void Delete(TKey id);
    }
}
