using CVTheque.client.ViewModels;
using CVTheque.Client.ViewModels;
using CVTheque.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CVTheque.Client.Services.Http
{
    interface IUserRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        Task<HttpResponseMessage> Login(ViewLogin user);
        Task<HttpResponseMessage> Register(ViewUser user);
        Task<HttpResponseMessage> GetByUsername(string username);
        Task<bool> PostAvailable(ViewUser user);
    }
}
