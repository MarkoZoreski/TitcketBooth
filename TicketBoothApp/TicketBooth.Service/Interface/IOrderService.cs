using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Service.Interface
{
    public interface IOrderService
    {
        Order CreateOrder(List<Ticket> tickets, string userId);

        void DeleteOrder(Guid orderId);

    }
}
