using Distributed_Caching.Models;
using Microsoft.EntityFrameworkCore;

namespace Distributed_Caching.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
