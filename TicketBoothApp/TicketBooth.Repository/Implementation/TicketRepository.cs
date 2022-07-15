using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;

namespace TicketBooth.Repository.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Ticket> _entities;
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<Ticket>();
        }

        public void Delete(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public Ticket Get(Guid? id)
        {
            return _entities.Where(s => s.Id.Equals(id))
                .Include(s => s.Theater)
                .Include(s => s.Order)
                    .ThenInclude(o => o.Theater)
                        .ThenInclude(s => s.Movie)
                .FirstOrDefault();
        }

        public List<Ticket> GetAll()
        {
            return _entities.Include(s => s.Theater)
                .Include(s => s.Order)
                    .ThenInclude(o => o.Theater)
                        .ThenInclude(s => s.Movie)
                .ToList();
        }

        public void Insert(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Ticket entity)
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
