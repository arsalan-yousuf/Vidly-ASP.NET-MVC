using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWebApp.Models;
using FirstWebApp.ViewModels;
using System.Data.Entity;

namespace FirstWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext _context;
        public MoviesController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //public ActionResult Index()
        //{
        //    var movies = new List<Movie>
        //    {
        //        new Movie { Name="Shrek"},
        //        new Movie {Name="Pink Panther"},
        //        new Movie {Name="Spider Man"},
        //        new Movie {Name="Iron Man"}
        //    };

        //    ViewBag.movies = movies;
        //    return View();


        //}
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name="Arsalan"},
                new Customer {Name="Hammad"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //ViewBag.Movie = movie;
            return View(viewModel);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        }

        //GET: movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            //var movies = new List<Movie>
            //{
            //    new Movie { Name="Shrek"},
            //    new Movie {Name="Pink Panther"},
            //    new Movie {Name="Spider Man"},
            //    new Movie {Name="Iron Man"}
            //};

            var movies = _context.Movies.Include(c => c.Genre).ToList();
            ViewBag.movies = movies;
            return View();
            //return Content(String.Format("PageIndex: {0}, SortBy: {1}", pageIndex, sortBy));
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.movieDetails = movie;
            return View();
        }

        public ActionResult New()
        {
            ViewBag.genres = _context.Genres.ToList();

            return View();
        }

        public ActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(c => c.Id == id);
            ViewBag.genres = _context.Genres.ToList();
            return View("New", movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        
    }
}