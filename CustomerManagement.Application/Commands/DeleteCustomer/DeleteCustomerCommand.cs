using MediatR;
using System;

namespace CustomerManagement.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid CustomerId { get; set; }
    }
}
