using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace IFSP.ADS.API.Middlewares
{
    public class RequestIdMiddleware : OwinMiddleware
    {
        public RequestIdMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            IOwinRequest req = context.Request;
            IOwinResponse res = context.Response;
            if (req.Method != "OPTIONS")
            {
                var requestId = Guid.NewGuid().ToString("N");
                req.Set("owin.RequestId", requestId);
                res.Headers.Append("Access-Control-Expose-Headers", "X-Request-Id");
                res.Headers.Append("X-Request-Id", requestId);
            }
            await Next.Invoke(context);
        }
    }
}