using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Repository.Interface
{
    public interface IMovieRepository
    {

        IEnumerable<Movie> GetAll();
        Movie Get(Guid? id);
        void Insert(Movie entity);
        void Update(Movie entity);
        void Delete(Movie entity);
    }

}
