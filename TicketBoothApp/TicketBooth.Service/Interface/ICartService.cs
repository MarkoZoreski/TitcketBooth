using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Service.Interface
{
        public interface ICartService
        {
            Cart FindById(Guid id);

            List<Order> GetAllOrders(Guid cartId);

            void AddOrderToCart(Order order, string userid);

            void ClearCart(Guid cartId);

            void RemoveOrder(Guid cartId, Guid orderId);

        }
    
}

