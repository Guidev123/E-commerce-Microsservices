using Microsoft.AspNetCore.Authentication;
using System.Net;

namespace YourSneaker.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext) 
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpExceptionRequest ex)
            {
                HandleRequestExceptionAsync(httpContext, ex); 
            }
        }
        public static void HandleRequestExceptionAsync(HttpContext context, CustomHttpExceptionRequest httpRequestexcpetion)
        {
            if(httpRequestexcpetion.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)httpRequestexcpetion.StatusCode;
        }
    }
}
