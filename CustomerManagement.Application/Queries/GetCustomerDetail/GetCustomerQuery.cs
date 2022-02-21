using MediatR;
using System;

namespace CustomerManagement.Application.Queries.GetCustomerDetail
{
    public class GetCustomerQuery : IRequest<CustomerViewModel>
    {
        public Guid Id { get; set; }
    }
}
