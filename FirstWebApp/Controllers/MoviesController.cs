using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWebApp.Models;
using FirstWebApp.ViewModels;

namespace FirstWebApp.Controllers
{
    public class MoviesController : Controller
    {

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
        
        // GET: movies/edit/1
        public ActionResult Edit(int id)
        {
            return Content("ID = " + id); 
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

            var movies = new List<Movie>
            {
                new Movie { Name="Shrek"},
                new Movie {Name="Pink Panther"},
                new Movie {Name="Spider Man"},
                new Movie {Name="Iron Man"}
            };

            ViewBag.movies = movies;
            return View();
            //return Content(String.Format("PageIndex: {0}, SortBy: {1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        
    }
}