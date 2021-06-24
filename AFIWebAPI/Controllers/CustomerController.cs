using AFIWebAPI.Models;
using AFIWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AFIWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var messages = customerRepository.GetCustomers();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                var messages = customerRepository.GetCustomerById(id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            try
            {
                var messages = customerRepository.PostCustomer(customer);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/{Email}")]
        public IActionResult UpdateCustomerEmail(Guid id, string Email)
        {
            try
            {
                var messages = customerRepository.UpdateCustomerEmail(id, Email);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                var messages = customerRepository.DeleteCustomer(id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
