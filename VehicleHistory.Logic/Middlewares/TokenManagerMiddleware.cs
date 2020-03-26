using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.Logic.Middlewares
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private ITokenService _tokenService;
        public TokenManagerMiddleware(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await _tokenService.IsCurrentActiveToken())
            {
                await next(context);

                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
