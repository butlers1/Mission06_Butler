using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Butler.Models;
using System.Linq;

namespace Mission06_Butler.Controllers
    // Main controller for the application, handles routing and logic for pages
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            // Include category information and order movies by title
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        public IActionResult AboutJoel()
        {
            return View();
        }

        // GET method for the movie form, used for creating/editing movies
        [HttpGet]
        public IActionResult MovieForm()
        {
            // Pass the list of categories to the view for the dropdown menu
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            // validate data
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // If validation fails, reload the categories for the dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the movie record to edit based on ID
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            // Validate the updated movie information
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", updatedInfo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the movie record to delete based on ID
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            // Remove the movie record from the db, and save changes
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}