using System;
namespace CustomerManagement.Application.Queries.GetCustomerByName
{
    public class CustomerListByNameViewModel
    {
        //ViewModel for the client application
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
