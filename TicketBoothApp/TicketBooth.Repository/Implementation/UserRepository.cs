using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.Identity;
using TicketBooth.Repository.Interface;

namespace TicketBooth.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<TicketBoothUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<TicketBoothUser>();
        }
        public void Delete(TicketBoothUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public TicketBoothUser Get(string userName)
        {
            return entities
              .SingleOrDefault(s => s.UserName == userName);
        }

        public IEnumerable<TicketBoothUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(TicketBoothUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(TicketBoothUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
