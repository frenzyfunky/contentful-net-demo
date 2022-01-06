using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Filters
{
    public class SlowModeFilter : ActionFilterAttribute
    {
        private readonly int _expireMinutes;

        public SlowModeFilter(int expireMinutes)
        {
            _expireMinutes = expireMinutes;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _memoryCache = context.HttpContext.RequestServices.GetService(typeof(IMemoryCache)) as IMemoryCache;

            var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
            var cachedIp = _memoryCache.Get<IPAddress>(ipAddress.ToString());

            if (cachedIp != null)
            {
                context.Result = new RedirectToActionResult("Index", "Contact", null);
            }

            _memoryCache.Set(ipAddress.ToString(), ipAddress, new MemoryCacheEntryOptions 
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_expireMinutes)
            });
        }
    }
}
