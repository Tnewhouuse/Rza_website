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
        public async Task<List<Ticketbooking>> GetTicketBookingAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketBookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }
    }
}


