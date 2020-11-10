using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api
{
    public class VATSIMiddleware
    {
        private RequestDelegate next;

        public VATSIMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/middleware/pilots")
            {
                await context.Response.WriteAsync("DUUUUUUUDE");
            }
            else
            {
                await next(context);
            }
        }
    }
}