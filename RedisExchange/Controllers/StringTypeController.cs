using Microsoft.AspNetCore.Mvc;
using RedisExchange.Services;

namespace RedisExchange.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;
        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(0);
            db.StringSet("user", "Murad");
            db.StringSet("product", "car");

            return View();
        }
    }
}
