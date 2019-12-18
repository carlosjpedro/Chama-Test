using System.Threading.Tasks;
using Chama.Signup.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Chama.Signup.Api
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ChamaException e)
            {

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { error = e.Message }));
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
}
