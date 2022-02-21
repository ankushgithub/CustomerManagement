using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Db
{
    public class CustomerManagementDbContext : DbContext
    {
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
    }
}
