using System;

namespace CustomerManagement.Application.Queries.GetCustomerList
{
    //ViewModel for the client application
    public class CustomerListViewModel    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
