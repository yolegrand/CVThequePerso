using CvTheque.Core.Repositories;
using CvTheque.Data.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace WebApiCvTheque.Services
{
    public class BasicAuthentification : Attribute, IAuthenticationFilter
    {
        private UserService _UserService = new UserService();
        private readonly string Realm;
        public bool AllowMultiple { get { return false; } }
        public BasicAuthentification(string Realm)
        {
            this.Realm = "realm=" + Realm;
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage req = context.Request;
            try
            {
                if (req.Headers.Authorization == null || !req.Headers.Authorization.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
                    throw new UnauthorizedAccessException();

                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string credendials = encoding.GetString(Convert.FromBase64String(req.Headers.Authorization.Parameter));
                string[] Parts = credendials.Split(':');
                string userId = Parts[0].Trim();
                string password = Parts[1].Trim();

                if (userId == "" || !_UserService.Authentication(userId, password))
                    throw new UnauthorizedAccessException();
                var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userId)
                };
                var Id = new ClaimsIdentity(Claims, "Basic");
                var principal = new ClaimsPrincipal(new[] { Id });
                
            }
            catch(UnauthorizedAccessException)
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
            }
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result, Realm);
            return Task.FromResult(0);
        }
    }
}