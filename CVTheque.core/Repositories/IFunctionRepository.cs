using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface IFunctionRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        T GetByName(string Name);
    }
}
