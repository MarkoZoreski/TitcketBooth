using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Domain.Identity;
using TicketBooth.Repository.Interface;

namespace TicketBooth.Repository.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Cart> _entities;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<Cart>();
        }
        public List<Order> FindAllOrdersFromUser(TicketBoothUser user)
        {
            return _entities.Where(s => s.OwnerId == user.Id)
                .Include(s => s.OrdersInCart)
                .FirstOrDefault()
                .OrdersInCart;
                ;
        }

        public Cart FindById(Guid id)
        {
            return _entities.Include(s => s.OrdersInCart)
                .Include(s => s.Owner)
                .FirstOrDefault(s => s.Id.Equals(id));
        }

        public Order FindLatestFromUser(TicketBoothUser user)
        {
            var orderlist = FindAllOrdersFromUser(user);
            return orderlist[orderlist.Count - 1];
        }

        public void Save(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(cart);
            _context.SaveChanges();
        }

        public void Update(Cart entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
