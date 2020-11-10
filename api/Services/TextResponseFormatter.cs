using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Response: {content}\n");
        }        
    }
}