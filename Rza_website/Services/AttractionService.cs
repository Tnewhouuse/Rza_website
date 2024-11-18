using Microsoft.EntityFrameworkCore;
using Rza_website.Models;
namespace Rza_website.Services
{
    public class AttractionService
    {
        private readonly TlS2302280RzaContext _context;
        public AttractionService(TlS2302280RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}

