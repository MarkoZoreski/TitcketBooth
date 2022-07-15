using TicketBooth.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBooth.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> FindAll();

        Order Get(Guid? id);
        void Insert(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}
