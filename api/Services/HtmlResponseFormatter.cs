using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api.Services
{
    public class HtmlResponseFormatter : IResponseFormatter
    {
        public async Task Format(HttpContext context, string content)
        {
            context.Response.ContentType = "text/html";
            // the dollar sign allows for string interpolation of variable values
            // the @ creates a literal string where all whitespace and formatting is preserved
            await context.Response.WriteAsync($@"
                <!DOCTYPE html> 
                <html lang=""en""> 
                <head>
                    <title>Html Response</title>
                </head> 
                <body> 
                    <h2>Html Formatted Response</h2> 
                    <span>{content}</span>
                </body>
                </html>");                
        }
    }
}