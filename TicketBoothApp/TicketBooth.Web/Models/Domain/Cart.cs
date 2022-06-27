using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBooth.Web.Models.Identity;

namespace TicketBooth.Web.Models.Domain
{
    public class Cart : BaseEntity
    {
        public string OwnerId { get; set; }
        public TicketBoothUser Owner { get; set; }
        public bool Active { get; set; }

        public virtual List<Order> Orders { get; set; }

    }
}
