using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

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

        //Get all records 
        public List<Movies> GetMovies()
        {
            List<Movies> movies = (from m in _dbContext.Movies
                                   select m).ToList();

            return movies;
        }

        //Get a record MovieDetails
        public Movies GetMovieDetails(int movieId)
        {
            Movies movie = (from u in _dbContext.Movies
                            where u.MovieId == movieId
                            select u).Include(x => x.Genres)
                                     .Include(x => x.Awards)
                                     .FirstOrDefault();

            movie.Genres.Movies = null;

            return movie;
        }

        //Get details of all records
        public List<Movies> GetMoviesDetails()
        {
            List<Movies> movies = (from u in _dbContext.Movies
                                   select u).Include(u => u.Genres)
                                            .Include(u => u.Awards)
                                            .ToList();

            return movies;
        }
        #endregion

        #region POST
        //Insert record
        public void InsertMovie(Movies movie)
        {
            _dbContext.Movies.Add(movie);   
            _dbContext.SaveChanges();   
        }
        #endregion

        #region PUT
        //Update record 
        public void UpdateMovie(Movies movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified; ;
            _dbContext.SaveChanges();
        }
        #endregion

        #region DELETE
        // Delete record
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
