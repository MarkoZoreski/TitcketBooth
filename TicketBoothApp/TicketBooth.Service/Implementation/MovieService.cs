using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;
using TicketBooth.Service.Interface;

namespace TicketBooth.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void Create(Movie entity)
        {
            entity.Id = Guid.NewGuid();
            _movieRepository.Insert(entity);
        }

        public void Delete(Guid id)
        {
            Movie movie = _movieRepository.Get(id);
            _movieRepository.Delete(movie);
        }

        public List<Movie> FindAll()
        {
            return _movieRepository.GetAll().ToList();
        }

        public Movie FindById(Guid? Id)
        {
            if (Id == null) return null;

            return _movieRepository.Get(Id);
        }

        public List<string> GetAllGenres()
        {
            return _movieRepository.GetAll()
                .Select(m => m.MovieGenre)
                .Distinct()
                .ToList();
        }

        public void Update(Movie entity)
        {
            _movieRepository.Update(entity);
        }
    }
}
