using System;
using System.Collections.Generic;

namespace Rza_website.Models;

public partial class Ticketbooking
{
    public int TicketbookingId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DateBooked { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
