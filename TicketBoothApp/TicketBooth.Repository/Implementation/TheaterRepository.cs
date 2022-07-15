using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;

namespace TicketBooth.Repository.Implementation
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Theater> _entities;

        public TheaterRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<Theater>();
        }
        public void Delete(Theater entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public Theater Get(Guid? id)
        {
            return _entities.Where(s => s.Id.Equals(id)).Include(s => s.Movie).FirstOrDefault();
        }

        public List<Theater> GetAll()
        {
            return _entities.Include(s => s.Movie).ToList();
        }

        public void Insert(Theater entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Theater entity)
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
