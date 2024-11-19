using Microsoft.EntityFrameworkCore;
using Rza_website.Models;
namespace Rza_website.Services
{
    public class TicketService
    {
        private readonly TlS2302280RzaContext _context;
        public TicketService(TlS2302280RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }

    }

}

