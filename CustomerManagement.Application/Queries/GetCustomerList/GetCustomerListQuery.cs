using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<List<CustomerListViewModel>>
    {
    }
}
