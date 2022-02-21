using CustomerManagement.Application.Contracts;
using CustomerManagement.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IGenericAsyncRepository<Customer> _customerRepository;

        public DeleteCustomerCommandHandler(IGenericAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if(customer == null)
            {
                // throw an exception if customer is not found
                throw new Exception($"Customer with Id: {request.CustomerId} is not found");
            }
            await _customerRepository.DeleteAsync(customer);
            return Unit.Value;
        }
    }
}
