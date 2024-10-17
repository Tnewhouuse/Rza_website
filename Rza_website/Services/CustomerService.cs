using Rza_website.Models;
using Microsoft.EntityFrameworkCore;



namespace Rza_website.Services
{
    public class CustomerService

    {
        private readonly TlS2302280RzaContext _context;
        public CustomerService(TlS2302280RzaContext context)
        {
            _context = context;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

    }
}

