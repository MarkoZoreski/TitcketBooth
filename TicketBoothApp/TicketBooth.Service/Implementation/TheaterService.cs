using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;
using TicketBooth.Service.Interface;

namespace TicketBooth.Service.Implementation
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;

        public TheaterService(ITheaterRepository theaterRepository, IMovieRepository movieRepository, IOrderRepository orderRepository, ITicketRepository ticketRepository)
        {
            _theaterRepository = theaterRepository;
            _movieRepository = movieRepository;
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
        }
        public void Create(Theater theater)
        {
            theater.Id = Guid.NewGuid();
            Movie movie = _movieRepository.Get(theater.MovieId);
            theater.Movie = movie;

            _theaterRepository.Insert(theater);
        }

        public void Delete(Guid id)
        {
            var theater = _theaterRepository.Get(id);
            _theaterRepository.Delete(theater);
        }

        public List<Theater> FindAll()
        {
            return _theaterRepository.GetAll().ToList();
        }

        public List<Theater> FindAllByDate(DateTime date)
        {
            return _theaterRepository.GetAll()
                .Where(s => s.Date.Date == date.Date)
                .ToList();
        }

        public int FindAvailableTickets(Guid id)
        {
            var theater = this.FindById(id);
            int ticketsSold = _ticketRepository.GetAll()
                .Where(t => t.TheaterId.Equals(id))
                .Count();

            return theater.MaxSeats - ticketsSold;
        }

        public Theater FindById(Guid? id)
        {
            return _theaterRepository.Get(id.Value);
        }

        public void Update(Theater screaning)
        {
            _theaterRepository.Update(screaning);
        }
    }
}
