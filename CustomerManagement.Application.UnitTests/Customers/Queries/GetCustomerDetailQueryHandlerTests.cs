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
using CustomerManagement.Application.Queries.GetCustomerDetail;

namespace CustomerManagement.Application.UnitTests.Customers.Queries
{
    public class GetCustomerDetailQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        public GetCustomerDetailQueryHandlerTests()
        {
            _mockCustomerRepository = CustomerRepositoryMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(m =>
            {
                m.AddProfile<CustomerMappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCustomerDetailTest()
        {
            var handler = new GetCustomerQueryHandler(_mockCustomerRepository.Object, _mapper);
            var result = await handler.Handle(new GetCustomerQuery() { Id = new System.Guid("d8b6c7f1-b36d-4b58-a347-82762d4db1d4") }, CancellationToken.None);

            result.Should().BeOfType<CustomerViewModel>();
            result.LastName.Should().Be("Damon");
        }

    }
}
