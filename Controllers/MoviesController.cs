using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
namespace WebApp1.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult List()
        {
            var movie = new Movie() { Id=1, Name = "Titanic" };
            //return View(movie);
            //return Content("Hello Movies");
            return RedirectToAction("Index", "Home", new { param = 1, paramn2 = 2 });
        }

        
    }
}