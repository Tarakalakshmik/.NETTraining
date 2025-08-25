using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC9.Models;
namespace CC9.Repositories
{
    public interface IMoviesRepository
    {


        IEnumerable<Movies> GetAll();
        Movies GetById(int id);
        void Add(Movies movie);
        void Update(Movies movie);
        void Delete(int id);
        IEnumerable<Movies> GetByYear(int year);
        IEnumerable<Movies> GetByDirector(string directorName);
        void Save();

    }
}