using AutoMapper;
using CustomerManagement.Application.Contracts;
using CustomerManagement.Application.Queries.GetCustomerByName;
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
    public class SearchCustomerByNameQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        public SearchCustomerByNameQueryHandlerTests()
        {
            _mockCustomerRepository = CustomerRepositoryMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(m =>
            {
                m.AddProfile<CustomerMappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task SearchCustomersByNameTest()
        {
            var handler = new SearchCustomersByNameQueryHandler(_mapper, _mockCustomerRepository.Object);
            var result = await handler.Handle(new SearchCustomersByNameQuery() { Name = "Adam"}, CancellationToken.None);

            result.Should().BeOfType<List<CustomerListByNameViewModel>>();
            result.Count.Should().Be(1);
        }

    }
}
