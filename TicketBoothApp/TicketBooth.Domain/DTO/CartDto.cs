using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.Relations;

namespace TicketBooth.Domain.DTO
{
    public class CartDto
    {
        public List<TicketInCart> Tickets { get; set; }

        public double TotalPrice { get; set; }
    }
}
