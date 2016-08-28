using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace IFSP.ADS.API.Middlewares
{
    public class CorsMiddleware : OwinMiddleware
    {
        public CorsMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            IOwinRequest req = context.Request;
            IOwinResponse res = context.Response;

            var origin = req.Headers.Get("Origin");
            if (!string.IsNullOrEmpty(origin))
            {
                res.Headers.Set("Access-Control-Allow-Origin", origin);
            }
            if (req.Method == "OPTIONS")
            {
                res.StatusCode = 200;
                res.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Credentials", "true");
                res.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Methods", "GET", "POST", "OPTIONS", "PUT", "DELETE");
                res.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Headers", "access-control-allow-origin", "accept", "access-control-allow-credentials", "access-control-allow-headers", "authorization", "access-control-allow-methods", "content-type");

                return;
            }
            res.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Credentials", "true");
            res.Headers.AppendCommaSeparatedValues("RequestId", Guid.Parse(req.Get<string>("owin.RequestId")).ToString("N"));

            await Next.Invoke(context);
        }
    }
}