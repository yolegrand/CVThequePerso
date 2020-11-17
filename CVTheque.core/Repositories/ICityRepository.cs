using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface ICityRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        T GetByName(string Name);
    }
}
