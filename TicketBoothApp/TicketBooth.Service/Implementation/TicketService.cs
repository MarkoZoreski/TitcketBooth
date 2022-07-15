using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository.Interface;
using TicketBooth.Service.Interface;

namespace TicketBooth.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ITheaterRepository _theaterRepository;

        public TicketService(ITicketRepository ticketRepository, IMovieRepository movieRepository, ITheaterRepository theaterRepository)
        {
            _ticketRepository = ticketRepository;
            _movieRepository = movieRepository;
            _theaterRepository = theaterRepository;
        }
        public List<Ticket> GetAllTickets(string userId)
        {
            List<Ticket> temp = _ticketRepository.GetAll()
                .Where(t => t.UserId.Equals(userId))
                .ToList();

            foreach (var ticket in temp)
            {
                var movieName = _theaterRepository.Get(ticket.TheaterId).Movie.MovieName;
                ticket.Movie = movieName;
            }

            return temp;
        }
    }
}
