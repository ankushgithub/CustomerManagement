using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCustomerDetail
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerViewModel>
    {
        private readonly IGenericAsyncRepository<Customer> _asyncRepository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IGenericAsyncRepository<Customer> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<CustomerViewModel> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _asyncRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}
