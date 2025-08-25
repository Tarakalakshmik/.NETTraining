using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9.Models;
using CC9.Repositories;
namespace CC9.Controllers
{
    public class MoviesController : Controller
    {
        IMoviesRepository repo = new MoviesRepository();
        // GET: Movies
        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            return View(movies);
        }
    }
}






