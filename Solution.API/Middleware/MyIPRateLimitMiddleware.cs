using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Solution.API.Middleware
{
    public class MyIPRateLimitMiddleware : IpRateLimitMiddleware
    {
        public MyIPRateLimitMiddleware
            (
            RequestDelegate next,
            IOptions<IpRateLimitOptions> options,
            IRateLimitCounterStore counterStore,
            IIpPolicyStore policyStore,
            IRateLimitConfiguration config,
            ILogger<IpRateLimitMiddleware> logger
            ) : base(next, options, counterStore, policyStore, config, logger)
        {
        }

        public override Task ReturnQuotaExceededResponse(HttpContext httpContext, RateLimitRule rule, string retryAfter)
        {
            //  return base.ReturnQuotaExceededResponse(httpContext, rule, retryAfter);
            string str = string.Format("API calls quata exceeded! maximum admitted {0} per {1}", rule.Limit,
                rule.Period);
            var result = JsonConvert.SerializeObject(new { error = str });
            httpContext.Response.Headers["Retry-After"] = retryAfter;
            httpContext.Response.StatusCode = 429;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(result);
        }
    }
}
