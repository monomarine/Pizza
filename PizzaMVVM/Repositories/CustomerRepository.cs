using Microsoft.EntityFrameworkCore;
using PizzaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVVM.Repositories
{
#pragma warning disable
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly PizzaDbContext _context = new();

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = _context.Customers
                .FirstOrDefault(x=> x.Id == id);

            if(customer != null) 
                _context.Customers.Remove(customer);

            await _context.SaveChangesAsync(true);
        }

        public Task<Customer> GetCustomerBuIdAsync(Guid id) =>
            _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        
             

        public Task<List<Customer>> GetCustomersAsync()=>
            _context.Customers.ToListAsync();

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if(!_context.Customers.Local.Any(x=> x.Id == customer.Id))
                _context.Customers.Attach(customer);

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;

        }
    }
}
