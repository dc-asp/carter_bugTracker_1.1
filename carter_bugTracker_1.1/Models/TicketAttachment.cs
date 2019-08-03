using carter_bugTracker_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1
{
    public class TicketAttachment
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AttachmentUrl { get; set; }
        public DateTime Created { get; set; }

        //Nav Properties
        
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser User { get; set; }



    }
}