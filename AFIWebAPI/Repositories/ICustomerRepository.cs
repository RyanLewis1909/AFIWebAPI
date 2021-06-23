using AFIWebAPI.ViewModels;
using AFIWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIWebAPI.Repositories
{
    public interface ICustomerRepository
    {
        List<CustomerViewModel> GetCustomers();
        List<CustomerViewModel> GetCustomerById(Guid id);
        string PostCustomer(Customer cus);
        string DeleteCustomer(Guid id);
    }
}
