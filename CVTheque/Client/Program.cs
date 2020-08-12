using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CVTheque.Client.Services.Http;
using CVTheque.Shared.Models;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using CVTheque.Client.Services.JS;

namespace CVTheque.Client
{
    static class Constants
    {
        public const string URL_BASE = "https://localhost:44374/api/";
    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("CVTheque", client =>
            {
                client.BaseAddress = new Uri($"{Constants.URL_BASE}");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddSingleton<IRepository<int, LevelApi>, LevelRepository>();
            builder.Services.AddSingleton<IRepository<int, LanguageLevelApi>, LanguageLevelRepository>();
            builder.Services.AddSingleton<IRepository<int, UserApi>, UserRepository>();
            builder.Services.AddSingleton<IUserRepository<int, UserApi>, UserRepository>();
            builder.Services.AddSingleton<LocalStorage>();
            builder.Services.AddScoped<IJsAlertifyService, JsAlertifyService>();
            await builder.Build().RunAsync();

        }
    }
}
