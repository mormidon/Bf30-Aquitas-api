using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Catalyte.Apparel.API.Helpers
{
    public class HttpExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = actionExecutedContext.Exception.InnerException == null
                    ? actionExecutedContext.Exception.Message
                    : actionExecutedContext.Exception.InnerException.Message
            };
        }
    }
}
