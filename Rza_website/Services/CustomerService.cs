using Rza_website.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            var hashedPassword = HashPassword(customer.Password);
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == hashedPassword);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Customers.AnyAsync(c => c.Username == username);
        }

        public async Task ChangePassword(int customerId, string hashedOldPassword, string hashedNewPassword)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(
                c => c.CustomerId == customerId &&
                c.Password == hashedOldPassword);

            if (customer != null)
            {
                customer.Password = hashedNewPassword;
                await _context.SaveChangesAsync();
            }
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
