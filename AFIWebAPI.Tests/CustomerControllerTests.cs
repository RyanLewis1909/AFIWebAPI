using System;
using Xunit;
using Moq;
using AFIWebAPI.Repositories;
using AFIWebAPI.Models;
using AFIWebAPI.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AFIWebAPI.Tests
{
    public class CustomerControllerTests
    {
        public CustomerController _sut;
        public Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();

        public CustomerControllerTests()
        {
            _sut = new CustomerController(mock.Object);
        }

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

            var result = _sut.GetCustomers() as ObjectResult;

            Assert.Equal(customer, result.Value);
        }

        [Fact]
        public void GetCustomers_NoneExist()
        {
            mock.Setup(p => p.GetCustomers()).Returns(() => null);

            var result = _sut.GetCustomers() as ObjectResult;

            Assert.Null(result);
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

            var result = _sut.GetCustomerById(id) as ObjectResult;

            Assert.Equal(customer, result.Value);
        }

        [Fact]
        public void GetCustomerById_DoesntExist()
        {
            mock.Setup(p => p.GetCustomerById(It.IsAny<Guid>())).Returns(() => null);

            var result = _sut.GetCustomerById(Guid.NewGuid()) as ObjectResult;

            Assert.Null(result);
        }

        [Fact]
        public void PostCustomer()
        {
            Guid id = Guid.NewGuid();
            string ret = "{\n\"id\": \"" + id + "\"\n}";
            var customerData = new Customer()
            {
                ID = id,
                FirstName = "TestName",
                Surname = "TestSurname",
                RefNo = "TT-123456",
                DateOfBirth = DateTime.Parse("1994/09/19"),
                Email = "test@example.com"
            };
            mock.Setup(p => p.PostCustomer(customerData)).Returns(ret);

            var result = _sut.PostCustomer(customerData) as ObjectResult;

            Assert.Equal(ret, result.Value);
        }

        [Fact]
        public void UpdateCustomerEmail()
        {
            Guid id = Guid.NewGuid();
            string email = "test@example.com";
            List<Customer> customer = new List<Customer>();
            var customerData = new Customer()
            {
                ID = id,
                FirstName = "TestName",
                Surname = "TestSurname",
                RefNo = "TT-123456",
                DateOfBirth = DateTime.Parse("1994/09/19"),
                Email = "test@example.com"
            };
            customer.Add(customerData);
            mock.Setup(p => p.UpdateCustomerEmail(id, email)).Returns(customer);

            var result = _sut.UpdateCustomerEmail(id, email);

            //Assert.Equal(customer, result.Value);
        }
    }
}
