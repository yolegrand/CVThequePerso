using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using CVTheque.client.ViewModels;
using CVTheque.Client.ViewModels;
using CVTheque.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CVTheque.Client.Services.Http
{
    public class UserRepository : IUserRepository<int, UserApi>
    {
        private readonly HttpClient _client;
        private readonly LocalStorage _storage;
        public UserRepository(HttpClient client, LocalStorage storage)
        {
            _client = client;
            _storage = storage;
        }
        public UserRepository()
        {
        }
        public async Task<HttpResponseMessage> Delete(int id, UserApi user)
        {
            string json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Console.WriteLine($"{Constants.URL_BASE}Users/" + id, content);
            return await _client.DeleteAsync($"{Constants.URL_BASE}Users/" + id);
        }

        public async Task<HttpResponseMessage> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"{Constants.URL_BASE}Users");
            request.Headers.Add("Accept", "application/json");
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetOne(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"{Constants.URL_BASE}Users/" + id);
            request.Headers.Add("Accept", "application/json");
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> Post(UserApi user)
        {
            //string json = JsonConvert.SerializeObject(user);
            //HttpContent content = new StringContent(json);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Console.WriteLine($"{Constants.URL_BASE}Users", content);
            //return await _client.PostAsync($"{Constants.URL_BASE}Users", content);
            string json = JsonConvert.SerializeObject(user);
            using (var req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}Users"))
            {
                req.Content = new StringContent(json, Encoding.Default, "application/json");
                return await _client.SendAsync(req);
            }
        }

        public async Task<HttpResponseMessage> Put(int id, UserApi user)
        {
            //string json = JsonConvert.SerializeObject(user);
            //HttpContent content = new StringContent(json);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Console.WriteLine($"{Constants.URL_BASE}Levels/" + id, content);
            //return await _client.PutAsync($"{Constants.URL_BASE}Users/" + id, content);
            string json = JsonConvert.SerializeObject(user);
            using (var req = new HttpRequestMessage(HttpMethod.Put, $"{Constants.URL_BASE}Users/" + id))
            {
                req.Content = new StringContent(json, Encoding.Default, "application/json");
                return await _client.SendAsync(req);
            }
        }

        public async Task<HttpResponseMessage> Login(ViewLogin user)
        {
            //string json = JsonConvert.SerializeObject(user);
            //HttpContent content = new StringContent(json);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Console.WriteLine($"{Constants.URL_BASE}Users/Login", content);

            string json = JsonConvert.SerializeObject(user);
            using(HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}Users/Login"))
            {
                try
                {
                    req.Content = new StringContent(json, Encoding.Default, "application/json");
                    var response = await _client.SendAsync(req);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        ViewReturnUser dto = JsonConvert.DeserializeObject<ViewReturnUser>(content);
                        _storage["token"] = dto.Token;
                        _storage["username"] = dto.Username;
                        _storage["role"] = dto.Roles.FirstOrDefault().ToString();
                    }
                    return response;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return null;
            }
            
        }

        public async Task<HttpResponseMessage> Register(ViewUser user)
        {
            string json = JsonConvert.SerializeObject(user);
            using (var req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}Users/Register"))
            {
                req.Content = new StringContent(json, Encoding.Default, "application/json");
                return await _client.SendAsync(req);
            }
        }

        public async Task<HttpResponseMessage> GetByUsername(string username)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"{Constants.URL_BASE}Users/GetUserByName/" + username);
            request.Headers.Add("Accept", "application/json");
            return await _client.SendAsync(request);
        }

        public async Task<bool> PostAvailable(ViewUser user)
        {
            var swAvailable = false;
            if(user.Username == "" || user.Username.Length <=3 || user.Username.Length > 30)
                return swAvailable;
            var json = JsonConvert.SerializeObject(user);
            using(HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}Users/available"))
            {
                req.Content = new StringContent(json, Encoding.Default, "application/json");
                using (var response = await _client.SendAsync(req))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        swAvailable = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            return swAvailable;
        }
    }
}
