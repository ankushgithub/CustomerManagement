using MediatR;
using System;

namespace CustomerManagement.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
