using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListViewModel>>
    {
        private readonly IGenericAsyncRepository<Customer> _asyncRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IGenericAsyncRepository<Customer> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<List<CustomerListViewModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _asyncRepository.GetAllAsync();
            return _mapper.Map<List<CustomerListViewModel>>(customers);
        }
    }
}
