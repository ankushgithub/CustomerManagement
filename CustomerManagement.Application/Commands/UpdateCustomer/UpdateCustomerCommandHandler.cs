using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Application.Exceptions;
using CustomerManagement.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IGenericAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IGenericAsyncRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if(customer == null)
            {
                // throw exception if customer is not found
                throw new Exception($"Customer with Id: {request.CustomerId} is not found");
            }

            var customerValidator = new UpdateCustomerCommandValidator();
            var validationResult = await customerValidator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, customer, typeof(UpdateCustomerCommand), typeof(Customer));

            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }

    }
}
