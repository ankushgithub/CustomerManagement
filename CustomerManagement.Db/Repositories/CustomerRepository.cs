using CustomerManagement.Application.Contracts;
using CustomerManagement.Model;
using CustomerManagement.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerManagementDbContext dbContext): base(dbContext)
        {

        }
        public async Task<List<Customer>> SearchCustomerByName(string name)
        {
            return await _dbContext.Customer.Where(customer => customer.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase)
            || customer.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
    }
}
