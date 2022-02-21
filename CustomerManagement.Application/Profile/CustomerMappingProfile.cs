using CustomerManagement.Application.Commands.CreateCustomer;
using CustomerManagement.Application.Queries.GetCustomerByName;
using CustomerManagement.Application.Queries.GetCustomerList;
using CustomerManagement.Application.Queries.GetCustomerDetail;
using CustomerManagement.Application.Commands.UpdateCustomer;
using CustomerManagement.Model;

namespace CustomerManagement.Application.Profile
{
    public class CustomerMappingProfile : AutoMapper.Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerListViewModel>().ReverseMap();
            CreateMap<Customer, CustomerListByNameViewModel>().ReverseMap();
        }
    }
}