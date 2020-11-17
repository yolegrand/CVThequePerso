using DalHttp.core.Models;
using DalHttp.core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DalHttp.Data.Repositories
{
    public class ProgramRepository : IProgramRepository<int, Program>
    {
        private readonly string BaseUri = @"https://localhost:44317/api/";
        private readonly string Mail = "jevrard@educassist.be";
        private readonly string Pass = "Choupetta";
        public bool Create(Program entity)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{Mail}:{Pass}")));

                    string Json = JsonConvert.SerializeObject(entity);
                    using (HttpContent _HttpContent = new StringContent(Json))
                    {
                        _HttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage _response = client.PostAsync("Program", _HttpContent).Result;
                        return _response.IsSuccessStatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return entity == null;
        }

        public bool Delete(int Id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{Mail}:{Pass}")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage _response = client.DeleteAsync("Program/" + Id).Result)
                    {
                        return _response.IsSuccessStatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Id == 0;
        }

        public IEnumerable<Program> GetAll()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{Mail}:{Pass}")));

                    using (HttpResponseMessage _response = client.GetAsync("Program").Result)
                    {
                        _response.EnsureSuccessStatusCode();
                        using (HttpContent _content = _response.Content)
                        {
                            string result = _content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<Program[]>(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public Program GetOne(int Id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{Mail}:{Pass}")));

                    using (HttpResponseMessage _response = client.GetAsync("Program/" + Id).Result)
                    {
                        _response.EnsureSuccessStatusCode();
                        using (HttpContent _content = _response.Content)
                        {
                            string result = _content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<Program>(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public bool Update(int Id, Program entity)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    string Json = JsonConvert.SerializeObject(entity);
                    using (HttpContent _HttpContent = new StringContent(Json))
                    {
                        _HttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{Mail}:{Pass}")));

                        using (HttpResponseMessage _response = client.PutAsync("Program/" + Id, _HttpContent).Result)
                        {
                            return _response.IsSuccessStatusCode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return entity == null;
        }
    }
}
