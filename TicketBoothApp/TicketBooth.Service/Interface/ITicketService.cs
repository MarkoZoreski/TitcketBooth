using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Service.Interface
{
        public interface ITicketService
        {
            List<Ticket> GetAllTickets(string userId);
        }
    
}
