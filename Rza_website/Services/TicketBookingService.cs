using Microsoft.EntityFrameworkCore;
using Rza_website.Models;

namespace Rza_website.Services
{
    public class TicketBookingService
    {
        private readonly TlS2302280RzaContext _context;
        public TicketBookingService(TlS2302280RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
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


