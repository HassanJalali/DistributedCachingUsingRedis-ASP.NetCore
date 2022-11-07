using Distributed_Caching.Extensions;
using Distributed_Caching.Models;
using Distributed_Caching.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;

namespace Distributed_Caching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private const string employeeListCacheKey = "employeeList";

        private readonly IEmployeeRepository<Employee> _repository;
        private readonly IDistributedCache _cache;
        private readonly ILogger<Employee> _logger;
        private static readonly SemaphoreSlim semaphore = new(1, 1);
        public EmployeeController(IEmployeeRepository<Employee> repository,
                                  IDistributedCache cache,
                                  ILogger<Employee> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            _logger.Log(LogLevel.Information, "Try to fetch employeeList from the cache");

            if (_cache.TryGetValue(employeeListCacheKey, out IEnumerable<Employee>? employees))
            {
                _logger.Log(LogLevel.Information, "EmployeeList Founded in the Cache");
            }

            else
            {
                try
                {
                    await semaphore.WaitAsync();
                    if (_cache.TryGetValue(employeeListCacheKey, out employees))
                    {
                        _logger.Log(LogLevel.Information, "employeeList Found in the cache");
                    }
                    else
                    {
                        _logger.Log(LogLevel.Information, "employeeList Does not Found in the cache, let's get data from the database");
                        employees = _repository.GetAll();

                        var cacheEntryOptions = new DistributedCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600));

                        await _cache.SetAsync(employeeListCacheKey, employees, cacheEntryOptions);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }
            return Ok(employees);


        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _repository.Add(employee);

            _cache.Remove(employeeListCacheKey);

            return new ObjectResult(employee) { StatusCode = (int)HttpStatusCode.Created };
        }
    }
}
