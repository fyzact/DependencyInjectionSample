using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.GuidGenerator
{
    public class RequestLoggingMiddeware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddeware(RequestDelegate next)
        {
            _next = next;

        }

        public Task Invoke(HttpContext context, ILogger<RequestLoggingMiddeware> logger)
        {
            logger.LogDebug("Request start");
            var result = _next.Invoke(context);
            logger.LogInformation("Request finist");
            return result;

        }
    }
}
