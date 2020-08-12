using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CVTheque.data.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using CVTheque.sata.Irepositories;
using CVTheque.data.Repositories;

namespace CVThequeApiCore
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                // If an authentication cookie is present, use it to get authentication information
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                // If authentication is required, and no cookie is present, use Okta (configured below) to sign in
                options.DefaultChallengeScheme = "Okta";
            })
.AddCookie() // cookie authentication middleware first
.AddOAuth("Okta", options =>
{
    // Oauth authentication middleware is second
    var oktaDomain = Configuration.GetValue<string>("Okta:OktaDomain");
    // When a user needs to sign in, they will be redirected to the authorize endpoint
    options.AuthorizationEndpoint = $"{oktaDomain}/oauth2/default/v1/authorize";
    // Okta's OAuth server is OpenID compliant, so request the standard openid
    // scopes when redirecting to the authorization endpoint
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");
    // After the user signs in, an authorization code will be sent to a callback
    // in this app. The OAuth middleware will intercept it
    options.CallbackPath = new PathString("/authorization-code/callback");
    // The OAuth middleware will send the ClientId, ClientSecret, and the
    // authorization code to the token endpoint, and get an access token in return
    options.ClientId = Configuration.GetValue<string>("Okta:ClientId");
    options.ClientSecret = Configuration.GetValue<string>("Okta:ClientSecret");
    options.TokenEndpoint = $"{oktaDomain}/oauth2/default/v1/token";
    // Below we call the userinfo endpoint to get information about the user
    options.UserInformationEndpoint = $"{oktaDomain}/oauth2/default/v1/userinfo";
    // Describe how to map the user info we receive to user claims
    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "sub");
    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "given_name");
    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            // Get user info from the userinfo endpoint and use it to populate user claims
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
            var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
            response.EnsureSuccessStatusCode();
            var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            context.RunClaimActions(user.RootElement);
        }
    };
});

            services.AddCors(policy =>
            {
                policy.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44317").AllowAnyHeader()
                                                                      .AllowAnyMethod();
                    });
                //services.AddCors(policy =>
                //{
                //    policy.AddPolicy(name: MyAllowSpecificOrigins,
                //        builder =>
                //        {
                //            builder.AllowAnyOrigin()
                //    .AllowAnyHeader()
                //    .AllowAnyMethod();
                //        });
                //});
            });
            
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("CVThequeCore"), b => b.MigrationsAssembly("CVTheque.api")));
            services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<Context>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
