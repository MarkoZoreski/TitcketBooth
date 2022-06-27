using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooth.Web.Models.Identity;

namespace TicketBooth.Web.Models.Domain
{
    public class Ticket : BaseEntity
    {
        public string UserId { get; set; }

        public TicketBoothUser User { get; set; }

        public string Movie { get; set; }

        public Guid TheaterId { get; set; }

        public Theater Theater { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
