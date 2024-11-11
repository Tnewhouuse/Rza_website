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
        public async Task<Customer?> LogIn(Customer customer)
        {

            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        
        }
        public async Task ChangePassword(int customerId, string hashedOldPassword, string hashedNewPassword)
        {
            Customer? customer = await _context.Customers.SingleOrDefaultAsync(
                c => c.CustomerId == customerId &&
                c.Password == hashedOldPassword);
            if (customer != null)
            {
                customer.Password = hashedNewPassword;
                await _context.SaveChangesAsync();
            }
        }
    }
}

