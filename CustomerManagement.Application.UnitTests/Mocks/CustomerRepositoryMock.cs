using CustomerManagement.Application.Contracts;
using CustomerManagement.Model;
using Moq;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Application.UnitTests.Mocks
{
    public class CustomerRepositoryMock
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var id1 = Guid.Parse("{15fe7729-6e1d-47a4-b9b5-f96bf7e44789}");
            var id2 = Guid.Parse("{d8b6c7f1-b36d-4b58-a347-82762d4db1d4}");
            var id3 = Guid.Parse("{17d9a250-36c9-41c1-8f8b-3da40f1c163d}");

            var customer1 =
                new Customer
                {
                    CustomerId = id1,
                    FirstName = "Adam",
                    LastName = "Smith",
                    DateOfBirth = Convert.ToDateTime("01/01/1980")
                };

            var customer2 = new Customer
            {
                CustomerId = id2,
                FirstName = "Matt",
                LastName = "Damon",
                DateOfBirth = Convert.ToDateTime("01/02/1980")
            };

            var customer3 = new Customer
            {
                CustomerId = id2,
                FirstName = "James",
                LastName = "Deam",
                DateOfBirth = Convert.ToDateTime("01/03/1980")
            };

            var customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);

            var filteredCustomerList = new List<Customer>();
            filteredCustomerList.Add(customer1);
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(c => c.GetAllAsync()).ReturnsAsync(customers);
            mockCustomerRepository.Setup(c => c.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(customer2);
            mockCustomerRepository.Setup(c => c.AddAsync(It.IsAny<Customer>())).ReturnsAsync(
                (Customer customer) =>
                {
                    customers.Add(customer);
                    return customer;
                });
            mockCustomerRepository.Setup(c => c.SearchCustomerByName("Adam")).ReturnsAsync(filteredCustomerList);

            return mockCustomerRepository;
        }


    }
}
