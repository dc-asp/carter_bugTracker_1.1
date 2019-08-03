using carter_bugTracker_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1
{
    public class TicketComment
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string AuthorId { get; set; } //AuthorId??
        public string CommentBody { get; set; }
        public DateTime Created { get; set; }

        //Nav Properties
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser Author { get; set; }


    }
}