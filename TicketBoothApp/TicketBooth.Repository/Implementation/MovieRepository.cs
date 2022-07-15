using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;

namespace TicketBooth.Repository.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Movie> entities;
        string errorMessage = string.Empty;

        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Movie>();
        }
        public IEnumerable<Movie> GetAll()
        {
            return entities.AsEnumerable();
        }

        public Movie Get(Guid? id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
