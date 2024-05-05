using IDistributedCacheRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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

        public IActionResult SetComplexData()
        {
            ProductModel model = new()
            {
                Id = 1,
                Name = "Bed",
                Price = "200"
            };

            string jsonData = JsonConvert.SerializeObject(model);

            _distributedCache.SetString("product:1", jsonData);

            return View();
        }

        public IActionResult GetComplexData()
        {
            var value = _distributedCache.GetString("product:1");

            ProductModel model = JsonConvert.DeserializeObject<ProductModel>(value);

            return View(model);
        }


        public IActionResult SetImageCache()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/carPhoto.jpg");

            byte[] bytePhoto = System.IO.File.ReadAllBytes(path);

            _distributedCache.Set("catImage", bytePhoto);

            return View();
        }

        public IActionResult GetImageCache()
        {
            var byteValue = _distributedCache.Get("catImage");        

            return File(byteValue,"image/jpg");
        }


    }
}
