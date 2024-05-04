using InMemoryCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public ProductController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {

            //if (!_memoryCache.TryGetValue<string>("Date", out string? dateCache))
            //{
            //    MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            //    options.AbsoluteExpiration = DateTime.Now.AddSeconds(10);
            //    options.Priority = CacheItemPriority.High;
            //    options.RegisterPostEvictionCallback((key, value, reason, state) =>
            //    {
            //        _memoryCache.Set<string>("callback", $"{key} --> {value} => Reason: {reason}");
            //    });


            //    _memoryCache.Set<string>("Date", DateTime.Now.ToString(), options);

            //}

            ProductModel productModel = new ProductModel
            {
                Id = 1,
                Name = "Car",
                Price = "35000"
            };

            _memoryCache.Set<ProductModel>("product", productModel);

            return View();
        }

        public IActionResult Show()
        {
            ViewBag.Date = _memoryCache.Get<string>("Date");

            _memoryCache.TryGetValue<string>("callback", out string? value);

            ViewBag.callback = value;

            _memoryCache.TryGetValue<ProductModel>("product", out ProductModel? product);

            ViewBag.Product = product;

            return View();
        }
    }
}
