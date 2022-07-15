using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;
using TicketBooth.Service.Interface;

namespace TicketBooth.Service.Implementation
{
    public class CartService : ICartService

    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITheaterRepository _theaterRepository;

        public CartService(ICartRepository cartRepository, IUserRepository userRepository, ITicketRepository ticketRepository, IOrderRepository orderRepository, ITheaterRepository theaterRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _orderRepository = orderRepository;
            _theaterRepository = theaterRepository;
        }
        public void AddOrderToCart(Order order, string userid)
        {
            var user = _userRepository.Get(userid);
            user.Cart.OrdersInCart.Add(order);
            
            _cartRepository.Update(user.Cart);
        }

        public void ClearCart(Guid cartId)
        {
            var cart = FindById(cartId);
            cart.OrdersInCart.Clear();
            _cartRepository.Update(cart);
        }

        public Cart FindById(Guid id)
        {
            return _cartRepository.FindById(id);
        }

        public List<Order> GetAllOrders(Guid cartId)
        {
            var cart = FindById(cartId);
            return cart.OrdersInCart;
        }

        public void RemoveOrder(Guid cartId, Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            var cart = _cartRepository.FindById(cartId);
            cart.OrdersInCart.Remove(order);
            _cartRepository.Update(cart);

        }
    }
}
