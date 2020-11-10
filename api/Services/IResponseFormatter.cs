using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}