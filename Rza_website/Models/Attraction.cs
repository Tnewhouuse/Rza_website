using System;
using System.Collections.Generic;

namespace Rza_website.Models;

public partial class Attraction
{
    public int AttractionId { get; set; }

    public string? Name { get; set; }

    public float? Price { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
