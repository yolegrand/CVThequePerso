using System;
using System.Collections.Generic;
using System.Text;

namespace DalHttp.core.Repositories
{
    public interface IKnowledgeRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
    }
}
