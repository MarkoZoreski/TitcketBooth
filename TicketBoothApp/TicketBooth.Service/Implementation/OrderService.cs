using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;
using TicketBooth.Service.Interface;

namespace TicketBooth.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITheaterRepository _theaterRepository;

        public OrderService(IUserRepository userRepository, ITicketRepository ticketRepository, IOrderRepository orderRepository, ITheaterRepository theaterRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _orderRepository = orderRepository;
            _theaterRepository = theaterRepository;
        }
        public Order CreateOrder(List<Ticket> tickets, string userId)
        {
            var order = new Order();
            var user = _userRepository.Get(userId);
            order.Cart = user.Cart;
            order.CartId = user.Cart.Id;
            order.TicketQuantity = tickets.Count;
            order.Tickets = tickets;
            order.Theater = tickets[0].Theater;
            order.TheaterId = tickets[0].TheaterId;
            order.MovieName = tickets[0].Movie;

            _orderRepository.Insert(order);
            return order;
        }

        public void DeleteOrder(Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            _orderRepository.Delete(order);

        }


    }
}
