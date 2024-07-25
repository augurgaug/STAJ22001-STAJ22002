using Microsoft.AspNetCore.Mvc;

using MyApi.Business.CustomerServ;
using MyApi.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }



        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var newCustomer = await _customerService.PostCustomer(customer);
            if (newCustomer == null)
            {
                return Conflict(new { message = "Kullanýcý adý daha önce alýnmýþ!" });
            }
            return CreatedAtAction("GetCustomer", new { id = newCustomer.CustomerId }, newCustomer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            return Ok(customers);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
        {
            var result = await _customerService.UpdateCustomer(id, updatedCustomer);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
