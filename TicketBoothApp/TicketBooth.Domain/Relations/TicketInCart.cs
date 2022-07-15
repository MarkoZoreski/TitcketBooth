using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Domain.Relations
{
    public class TicketInCart : BaseEntity
    {
        public Guid TicketId { get; set; }
        public virtual Ticket SelectedTicket { get; set; }

        public Guid CartId { get; set; }
        public virtual Cart UserCart { get; set; }

        public int Quantity { get; set; }
    }
}
