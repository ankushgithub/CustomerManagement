using CustomerManagement.Model;
using CustomerManagement.Db;
using System;

namespace CustomerManagement.API.IntegrationTests.Setup
{
    public static class SeedTestData
    {
        public static void InitializeTestDb(CustomerManagementDbContext context)
        {
            var customer1Id = Guid.Parse("{5e8b6eb6-f831-4508-8547-ecbb3153d617}");
            var customer2Id = Guid.Parse("{b151edb6-7323-4129-83f4-6f1f48832bd0}");

            context.Customer.Add(new Customer
            {
                CustomerId = customer1Id,
                FirstName = "Adam",
                LastName = "Smith",
                DateOfBirth = Convert.ToDateTime("01/01/1980")
            });

            context.Customer.Add(new Customer
            {
                CustomerId = customer2Id,
                FirstName = "Paul",
                LastName = "Newman",
                DateOfBirth = Convert.ToDateTime("01/01/1970")
            });
            context.SaveChanges();

        }
    }
}
