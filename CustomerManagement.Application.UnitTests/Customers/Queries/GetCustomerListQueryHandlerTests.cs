using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Application.Queries.GetCustomerList;
using CustomerManagement.Application.Profile;
using CustomerManagement.Application.UnitTests.Mocks;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Application.UnitTests.Customers.Queries
{
    public class GetCustomerListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;

        public GetCustomerListQueryHandlerTests()
        {
            _mockCustomerRepository = CustomerRepositoryMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(m =>
            {
                m.AddProfile<CustomerMappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCustomerListTest()
        {
            var handler = new GetCustomerListQueryHandler(_mockCustomerRepository.Object, _mapper);
            var result = await handler.Handle(new GetCustomerListQuery(), CancellationToken.None);
            result.Should().BeOfType<List<CustomerListViewModel>>();
            result.Count.Should().Be(3);
        }
    }
}
