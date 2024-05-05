using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace IDistributedCacheRedis.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        public ProductController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public IActionResult Index()
        {
            DistributedCacheEntryOptions options = new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(15)

            };
            _distributedCache.SetString("name", "Kamil", options);

            return View();
        }

        public IActionResult Show()
        {
            var value = _distributedCache.GetString("name");
            ViewBag.Value = value;

            return View();
        }

        public IActionResult Remove()
        {
            _distributedCache.Remove("name");

            return View();
        }

    }
}
