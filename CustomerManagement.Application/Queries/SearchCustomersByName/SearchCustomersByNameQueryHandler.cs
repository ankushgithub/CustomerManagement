using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace CustomerManagement.Application.Queries.GetCustomerByName
{
    public class SearchCustomersByNameQueryHandler : IRequestHandler<SearchCustomersByNameQuery, List<CustomerListByNameViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public SearchCustomersByNameQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerListByNameViewModel>> Handle(SearchCustomersByNameQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await _customerRepository.SearchCustomerByName(request.Name);
            return _mapper.Map<List<CustomerListByNameViewModel>>(customers);
        }
    }
}
