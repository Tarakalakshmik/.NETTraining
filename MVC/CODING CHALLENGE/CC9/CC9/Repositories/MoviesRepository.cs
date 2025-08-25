using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC9.Models;
using CC9.Repositories;
using System.Data;
using System.Data.Entity;
namespace CC9.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        MovieContext db = new MovieContext();
        public void Add(Movies movie)
        {
            db.Movies.Add(movie);
        }

        public void Delete(int id)
        {

            var movie = db.Movies.Find(id);
            if (movie != null)
                db.Movies.Remove(movie);

        }

        public IEnumerable<Movies> GetAll()
        {
           return db.Movies.ToList();
        }

        public IEnumerable<Movies> GetByDirector(string directorName)
        {
            return db.Movies.Where(m => m.DirectorName == directorName).ToList();
        }

        public Movies GetById(int id)
        {
           return db.Movies.Find(id);
        }

        public IEnumerable<Movies> GetByYear(int year)
        {
            return db.Movies.Where(m => m.DateOfRelease.Year == year).ToList();
        }

        public void Update(Movies movie)
        {
            db.Entry(movie).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}


