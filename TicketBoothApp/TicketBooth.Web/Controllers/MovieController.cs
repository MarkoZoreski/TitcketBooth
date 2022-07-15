using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooth.Domain.DomainModels;
using TicketBooth.Repository;
using TicketBooth.Service.Interface;

namespace TicketBooth.web.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;

        public MovieController(ApplicationDbContext context, IMovieService movieService, ITheaterService theaterservice)
        {
            _context = context;
            _movieService = movieService;
            _theaterService = theaterservice;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movie/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }

            var theaters = _theaterService.FindAll().Where(s => s.MovieId.Equals(id)).Where(s => s.Date >= DateTime.Today).ToList();
            List<int> availableTickets = new List<int>();
            foreach (var theater in theaters)
            {
                int num = _theaterService.FindAvailableTickets(theater.Id);
                availableTickets.Add(num);
            }
            ViewData["AvailableTickets"] = availableTickets;
            ViewData["theaters"] = theaters;

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create([Bind("Name,Genre,Id")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Create(movie);

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/id
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.FindById(id);

            return View(movie);
        }

        // POST: Movie/Edit/id
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(Guid id, [Bind("Name,Genre,Id")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _movieService.Update(movie);

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/id
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/id
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _movieService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
