using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1.Models
{
    public class TicketPriority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //nav
        public virtual ICollection<Ticket> Tickets { get; set; }

        public TicketPriority()
        {
            Tickets = new HashSet<Ticket>();
        }

    }
}