using CustomerManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Contracts
{
    public interface ICustomerRepository : IGenericAsyncRepository<Customer>
    {
        Task<List<Customer>> SearchCustomerByName(string name);
    }
}
