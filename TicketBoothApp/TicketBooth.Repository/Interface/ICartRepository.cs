using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Domain.Identity;

namespace TicketBooth.Repository.Interface
{
    public interface ICartRepository
    {
        Cart FindById(Guid id);

        List<Order> FindAllOrdersFromUser(TicketBoothUser user);

        Order FindLatestFromUser(TicketBoothUser user);

        void Save(Cart cart);

        void Update(Cart entity);
    }
}
