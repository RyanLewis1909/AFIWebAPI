using AFIWebAPI.Models;
using System;
using System.Collections.Generic;

namespace AFIWebAPI.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        List<Customer> GetCustomerById(Guid id);
        string PostCustomer(Customer cus);
        List<Customer> UpdateCustomerEmail(Guid id, string email);
        string DeleteCustomer(Guid id);
    }
}
