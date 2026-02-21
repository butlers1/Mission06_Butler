using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Butler.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_Butler.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        // Updated to pass the list of movies to the view
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .OrderBy(x => x.Title)
                .ToListAsync();

            return View(movies);
        }

        public IActionResult AboutJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the list after adding
            }

            return View(response);
        }

        // NEW: GET action to load the Edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            return View("MovieForm", recordToEdit); // Reusing the same form view
        }

        // NEW: POST action to save the changes
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("MovieForm", updatedInfo);
        }

        // NEW: GET action to show the Delete confirmation
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        // NEW: POST action to perform the deletion
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}