using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Display(Name = "Project Name")]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public int TicketTypeId { get; set; }
        [Display(Name = "Project Name")]
        public int TicketStatusId { get; set; }
        [Display(Name = "Project Name")]
        public int TicketPriorityId { get; set; }
        [Display(Name = "Project Name")]
        public string OwnerUserId { get; set; }
        [Display(Name = "Project Name")]
        public string AssignedToUserId { get; set; }
        [Display(Name = "Project Name")]

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        //Nav Properties
        public virtual Project Project  { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
        public virtual ApplicationUser OwnerUser{ get; set; }
        public virtual ApplicationUser AssignedToUser { get; set; }

        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual ICollection<TicketNotification> TicketNotifications { get; set; }

        public Ticket()
        {
            TicketComments = new HashSet<TicketComment>();
            TicketAttachments = new HashSet<TicketAttachment>();
            TicketHistories = new HashSet<TicketHistory>();
            TicketNotifications = new HashSet<TicketNotification>();
        }

    }
}