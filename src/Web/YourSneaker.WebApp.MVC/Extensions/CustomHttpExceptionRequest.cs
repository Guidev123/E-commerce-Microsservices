using System.Net;

namespace YourSneaker.WebApp.MVC.Extensions
{
    public class CustomHttpExceptionRequest : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpExceptionRequest() { }

        public CustomHttpExceptionRequest(string message, Exception innerException)
            : base(message, innerException) { }

        public CustomHttpExceptionRequest(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
