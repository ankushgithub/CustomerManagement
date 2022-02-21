using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Queries.GetCustomerByName
{
    public class SearchCustomersByNameQuery : IRequest<List<CustomerListByNameViewModel>>
    {
        public string Name { get; set; }

    }
}
