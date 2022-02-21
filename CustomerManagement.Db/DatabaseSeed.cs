using CustomerManagement.Application.Contracts;
using CustomerManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomerManagement.Db
{
    public class DatabaseSeed
    {
        public static void Initialize(CustomerManagementDbContext context)
        {
            context.Customer.Add(
                new Model.Customer
                {
                    CustomerId = new System.Guid(),
                    DateOfBirth = Convert.ToDateTime("01/01/1980"),
                    FirstName = "Ankush",
                    LastName = "kashyap"
                });
            context.SaveChanges();
        }
    }
}