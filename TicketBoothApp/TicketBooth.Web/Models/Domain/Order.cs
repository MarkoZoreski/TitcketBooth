using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooth.Web.Models.Domain
{
    public class Order : BaseEntity
    {
        public string MovieName { get; set; }

        public int TicketQuantity { get; set; }

        public Guid TheaterId { get; set; }

        public virtual Theater Theater { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public Guid CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
