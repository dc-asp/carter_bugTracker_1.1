using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using carter_bugTracker_1._1.Models;

namespace carter_bugTracker_1._1.Helpers
{
    public class TicketHelper : CommonHelper
    {
        public static List<Ticket> GetTicketsByPriority(string name)
        {
            return db.Tickets.Where(t => t.TicketPriority.Name == name).ToList();
        }
        public static List<Ticket> GetTicketsByStatus(string name)
        {
            return db.Tickets.Where(t => t.TicketStatus.Name == name).ToList();
        }
        public static List<Ticket> GetTicketsByType(string name)
        {
            return db.Tickets.Where(t => t.TicketType.Name == name).ToList();
        }
    }
}