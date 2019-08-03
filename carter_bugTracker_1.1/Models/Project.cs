using carter_bugTracker_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public Project()
        {
            Tickets = new HashSet<Ticket>();
        }

    }
}