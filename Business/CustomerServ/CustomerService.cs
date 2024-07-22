using MyApi.Data;
using MyApi.Customers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Business.CustomerServ
{
    public class CustomerService
    {
        private readonly MyDbContext _context;

        public CustomerService(MyDbContext context)
        {
            _context = context;
        }



        public async Task<Customer?> PostCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(u => u.Name == customer.Name && u.LastName== customer.LastName);
            if (existingCustomer != null)
            {
                return null;
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer ?? null;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
       
    }
}
