using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieReviews.Models;

namespace MovieReviews.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult Create(string movieName)
        {
            ViewData["Movie"] = movieName;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review, string movieName)
        {
            var movie = Movie.Read(movieName);
            movie.AddReviewToMovie(review);
            return RedirectToAction("Index", "Movie");
        }
    }
}