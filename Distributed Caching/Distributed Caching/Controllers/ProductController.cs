using Distributed_Caching.Data;
using Distributed_Caching.Extensions;
using Distributed_Caching.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Distributed_Caching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly DbContextClass _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<Product> _logger;
        private static readonly SemaphoreSlim semaphore = new(1, 1);

        public ProductController(DbContextClass context, IDistributedCache cache, ILogger<Product> logger)
        {
            _context = context;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{
        //    var products = _context.Products.ToList();
        //    _logger.Log(LogLevel.Information, "Trying to fetch the list of Products from cache.");

        //    if (_cache.TryGetValue(products, out IEnumerable<Product>? Products))
        //    {

        //    }
        //}

    }
}
