using CustomerManagement.Application.Commands.CreateCustomer;
using CustomerManagement.Application.Commands.UpdateCustomer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Application.Exceptions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
            services.AddTransient<IValidator<UpdateCustomerCommand>, UpdateCustomerCommandValidator>();
            return services;
        }
    }
}