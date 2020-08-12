using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace CVTheque.Client.Services.Http
{
    public interface IRepository<TKey, T> where T : class
    {
        Task<HttpResponseMessage> Get();
        Task<HttpResponseMessage> GetOne(TKey id);
        Task<HttpResponseMessage> Post(T entity);
        Task<HttpResponseMessage> Put(TKey id, T entity);
        Task<HttpResponseMessage> Delete(TKey id, T entity);
    }
}
