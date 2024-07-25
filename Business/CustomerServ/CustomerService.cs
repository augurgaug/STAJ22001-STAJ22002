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

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return false;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCustomer(int id, Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            customer.Name = updatedCustomer.Name;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;
            customer.TelNo = updatedCustomer.TelNo;
            customer.Ulke = updatedCustomer.Ulke;
            customer.Il = updatedCustomer.Il;
            customer.Ilce = updatedCustomer.Ilce;
            customer.Mahalle = updatedCustomer.Mahalle;
            customer.Sokak = updatedCustomer.Sokak;
            customer.BinaNo = updatedCustomer.BinaNo;
            customer.DaireNo = updatedCustomer.DaireNo;
            customer.Banka = updatedCustomer.Banka;
            customer.Iban = updatedCustomer.Iban;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
