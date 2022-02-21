﻿using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Application.Exceptions;
using CustomerManagement.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IGenericAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IGenericAsyncRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerValidator = new CreateCustomerCommandValidator();
            var validationResult = await customerValidator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var customer = _mapper.Map<Customer>(request);

            customer = await _customerRepository.AddAsync(customer);

            return customer.CustomerId;
        }
    }
}
