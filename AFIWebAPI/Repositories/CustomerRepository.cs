using AFIWebAPI.Models;
using AFIWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIWebAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomersContext db;

        public CustomerRepository(CustomersContext db)
        {
            this.db = db;
        }

        public List<CustomerViewModel> GetCustomers()
        {
            if (db != null)
            {
                List<CustomerViewModel> customers = new List<CustomerViewModel>();

                var result = from o in db.Customers
                             orderby o.FirstName ascending, o.Surname ascending
                             select o;

                foreach (var r in result)
                {
                    CustomerViewModel customer = new CustomerViewModel
                    {
                        ID = r.ID,
                        FirstName = r.FirstName,
                        Surname = r.Surname,
                        RefNo = r.RefNo,
                        DateOfBirth = r.DateOfBirth.Date,
                        Email = r.Email
                    };

                    customers.Add(customer);
                }

                return customers;
            }

            return null;
        }

        public List<CustomerViewModel> GetCustomerById(Guid id)
        {
            if (db != null)
            {
                List<CustomerViewModel> customers = new List<CustomerViewModel>();

                var result = db.Customers.Where(p => p.ID == id);
                foreach (var r in result)
                {
                    CustomerViewModel customer = new CustomerViewModel
                    {
                        ID = r.ID,
                        FirstName = r.FirstName,
                        Surname = r.Surname,
                        RefNo = r.RefNo,
                        DateOfBirth = r.DateOfBirth.Date,
                        Email = r.Email
                    };

                    customers.Add(customer);
                }

                return customers;
            }

            return null;
        }
        public string PostCustomer(Customer cus)
        {
            Guid id = Guid.NewGuid();

            // check age
            int age = DateTime.Now.Year - cus.DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < cus.DateOfBirth.DayOfYear)
            {
                age -= 1;
            }
            if (age < 18)
            {
                throw new ArgumentOutOfRangeException("Customers needs to be 18 years or older");
            }

            if (db != null)
            {
                db.Customers.Add(new Customer()
                {
                    ID = id,
                    FirstName = cus.FirstName,
                    Surname = cus.Surname,
                    RefNo = cus.RefNo,
                    DateOfBirth = cus.DateOfBirth,
                    Email = cus.Email
                });

                db.SaveChanges();
                return "{\n\"id\": \"" + id + "\"\n}";
            }

            return null;
        }

        public string DeleteCustomer(Guid id)
        {
            var cus = db.Customers.Find(id);
            if (cus == null)
            {
                throw new ArgumentOutOfRangeException("Customers does not exist");
            }
            db.Customers.Remove(cus);
            db.SaveChanges();

            return "Customer removed";
        }

    }
}
