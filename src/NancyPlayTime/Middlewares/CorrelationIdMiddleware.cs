using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace NancyPlayTime.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;

        private const string CorrelationId = "CorrelationId";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            string correlationId;
            var headers = context.Request.Headers;
            if (headers.ContainsKey(CorrelationId))
            {
                correlationId = headers[CorrelationId].First();
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
                headers.Add(CorrelationId, new StringValues(correlationId));
            }
            context.Response.Headers.Add(CorrelationId, new StringValues(correlationId));
            await _next(context);
        }
    }
}