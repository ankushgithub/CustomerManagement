using System;

namespace CustomerManagement.Application.Queries.GetCustomerDetail
{
    //ViewModel for the client application.
    public class CustomerViewModel
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
