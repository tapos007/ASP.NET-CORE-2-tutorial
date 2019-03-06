using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Solution.API.Middlewares
{
    public class MyIpRateLimitMiddleware : IpRateLimitMiddleware
    {
        public MyIpRateLimitMiddleware(RequestDelegate next
            , IOptions<IpRateLimitOptions> options
            , IRateLimitCounterStore counterStore
            , IIpPolicyStore policyStore
            , IRateLimitConfiguration config
            , ILogger<IpRateLimitMiddleware> logger)
            : base(next, options, counterStore, policyStore, config, logger)
        {
        }

        public override Task ReturnQuotaExceededResponse(HttpContext httpContext, RateLimitRule rule, string retryAfter)
        {
            //return base.ReturnQuotaExceededResponse(httpContext, rule, retryAfter);
            var message = new { rule.Limit, rule.Period, retryAfter };

            httpContext.Response.Headers["Retry-After"] = retryAfter;

            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(message));
        }
    }
}
