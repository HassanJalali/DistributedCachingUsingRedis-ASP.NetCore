using Distributed_Caching.Data;
using Distributed_Caching.Models;

namespace Distributed_Caching.Services
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(EmployeeContext));
        }
        public void Add(Employee entity)
        {
            _context.Add(entity);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}
