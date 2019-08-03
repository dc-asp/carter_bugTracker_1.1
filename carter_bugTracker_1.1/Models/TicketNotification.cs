using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1.Models
{
    public class TicketNotification
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string RecepientId { get; set; }
        public string SenderId { get; set; }
        public string Subject { get; set; }
        public string NotificationBody { get; set; }
        public DateTime Created { get; set; }
        public bool IsRead { get; set; }
        //Nav Properties
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser Recepient { get; set; }
        public virtual ApplicationUser Sender { get; set; }

    }
}