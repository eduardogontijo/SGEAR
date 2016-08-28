using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace IFSP.ADS.API.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult InternalServerError(string message)
        {
            return new HttpActionResult(HttpStatusCode.InternalServerError, message);
        }

        protected IHttpActionResult NotFound(string message)
        {
            return new HttpActionResult(HttpStatusCode.NotFound, message);
        }

        protected IHttpActionResult BadRequest(string message)
        {
            return new HttpActionResult(HttpStatusCode.BadRequest, message);
        }

        protected IHttpActionResult Unauthorized(string message)
        {
            return new HttpActionResult(HttpStatusCode.Unauthorized, message);
        }

        protected IHttpActionResult Json<T>(HttpStatusCode statusCode, T obj)
        {
            var ret = Json(obj).ExecuteAsync(CancellationToken.None).Result;
            return new HttpActionResult(statusCode, ret);
        }

        protected string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        #region HttpActionResult
        public class HttpActionResult : IHttpActionResult
        {
            public HttpResponseMessage Message { get; private set; }
            public HttpStatusCode StatusCode { get; private set; }

            public HttpActionResult(HttpStatusCode statusCode, string message)
            {
                StatusCode = statusCode;
                Message = new HttpResponseMessage(statusCode) { Content = new StringContent(message) };
            }
            public HttpActionResult(HttpStatusCode statusCode, HttpResponseMessage message)
            {
                StatusCode = message.StatusCode = statusCode;
                Message = message;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(Message);
            }
        }
        #endregion HttpActionResult
    }
}