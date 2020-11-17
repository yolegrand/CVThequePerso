using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http.Headers;

namespace WebApiCvTheque.Services
{
    public class ResultWithChallenge : IHttpActionResult
    {
        private readonly IHttpActionResult Next;
        private readonly string Realm;

        public ResultWithChallenge(IHttpActionResult Next, string Realm)
        {
            this.Next = Next;
            this.Realm = Realm;
        }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var res = await Next.ExecuteAsync(cancellationToken);
            if(res.StatusCode == HttpStatusCode.Unauthorized)
            {
                res.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", Realm));
            }
            return res;
        }
    }
}