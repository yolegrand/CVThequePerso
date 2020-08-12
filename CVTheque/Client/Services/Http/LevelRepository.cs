using CVTheque.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CVTheque.Client.Services.Http
{
    public class LevelRepository : IRepository<int, LevelApi>
    {
        private readonly HttpClient _client;
        public LevelRepository(HttpClient client)
        {
            _client = client;
        }
        public LevelRepository()
        {
        }

        public async Task<HttpResponseMessage> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"{Constants.URL_BASE}Levels");
            request.Headers.Add("Accept", "application/json");
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetOne(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"{Constants.URL_BASE}Levels/"+id);
            request.Headers.Add("Accept", "application/json");
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> Post(LevelApi level)
        {
            string json = JsonConvert.SerializeObject(level);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Console.WriteLine($"{Constants.URL_BASE}Levels", content);
            return await _client.PostAsync($"{Constants.URL_BASE}Levels", content);
        }

        public async Task<HttpResponseMessage> Put(int id, LevelApi level)
        {
            string json = JsonConvert.SerializeObject(level);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Console.WriteLine($"{Constants.URL_BASE}Levels/"+id,content);
            return await _client.PutAsync($"{Constants.URL_BASE}Levels/" + id, content);
        }


        public async Task<HttpResponseMessage> Delete(int id, LevelApi level)
        {
            string json = JsonConvert.SerializeObject(level);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Console.WriteLine($"{Constants.URL_BASE}Levels/" + id, content);
            return await _client.DeleteAsync($"{Constants.URL_BASE}Levels/" + id);
        }
    }
}
