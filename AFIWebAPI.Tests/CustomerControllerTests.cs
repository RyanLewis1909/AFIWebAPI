using System;
using Xunit;
using Moq;
using AFIWebAPI.Repositories;
using AFIWebAPI.Models;
using AFIWebAPI.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AFIWebAPI.Tests
{
    public class CustomerControllerTests
    {
        public Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();

        [Fact]
        public void GetCustomers()
        {
            List<Customer> customer = new List<Customer>();
            var customerData = new Customer()
            {
                ID = Guid.NewGuid(),
                FirstName = "TestName",
                Surname = "TestSurname",
                RefNo = "TT-123456",
                DateOfBirth = DateTime.Parse("1994/09/19"),
                Email = "test@example.com"
            };
            customer.Add(customerData);
            mock.Setup(p => p.GetCustomers()).Returns(customer);
            CustomerController cus = new CustomerController(mock.Object);
            var result = cus.GetCustomers() as ObjectResult;
            Assert.Equal(customer, result.Value);
        }

        [Fact]
        public void GetCustomerById()
        {
            Guid id = Guid.NewGuid();
            List<Customer> customer = new List<Customer>();
            var customerData = new Customer()
            {
                ID = id,
            };
            customer.Add(customerData);
            mock.Setup(p => p.GetCustomerById(id)).Returns(customer);
            CustomerController cus = new CustomerController(mock.Object);
            var result = cus.GetCustomerById(id) as ObjectResult;
            Assert.Equal(customer, result.Value);
        }
    }
}
