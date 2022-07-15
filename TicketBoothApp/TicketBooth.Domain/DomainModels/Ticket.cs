using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooth.Domain.Identity;
using TicketBooth.Domain.Relations;

namespace TicketBooth.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        public string UserId { get; set; }

        public string Movie { get; set; }

        public Guid TheaterId { get; set; }

        public Theater Theater { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

    }
}
