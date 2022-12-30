using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class MoviesDataAccess : IMoviesDataAccess
    {
        //Variable de tipo readonly para el constructor
        private readonly ApplicationDbContext _dbContext;

        //Constructor
        public MoviesDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET
        //Get  a record
        public Movies GetMovie(int movieId)
        {
            Movies movie = (from u in _dbContext.Movies
                            where u.MovieId == movieId
                            select u).FirstOrDefault();

            return movie;
        }

        //Obtener todos los registros
        public List<Movies> GetMovies()
        {
            List<Movies> movies = (from m in _dbContext.Movies
                                   select m).ToList();

            return movies;
        }
        #endregion

        #region POST
        public void InsertMovie(Movies movie)
        {
            _dbContext.Movies.Add(movie);   
            _dbContext.SaveChanges();   
        }
        #endregion

        #region PUT
        public void UpdateMovie(Movies movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified; ;
            _dbContext.SaveChanges();
        }
        #endregion

        #region DELETE
        // Delete a arecord
        public void DeleteMovie(int movieId)
        {
            Movies movie = (from e in _dbContext.Movies
                                 where e.MovieId == movieId
                                 select e).FirstOrDefault();

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
