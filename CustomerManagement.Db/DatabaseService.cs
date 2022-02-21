using CustomerManagement.Application.Contracts;
using CustomerManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomerManagement.Db
{
    public static class DatabaseService
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddDbContext<CustomerManagementDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "CustomerDB");
            });

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<CustomerManagementDbContext>();

                //Add a record for in-memory db
                DatabaseSeed.Initialize(context);
            }
                services.AddScoped(typeof(IGenericAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}