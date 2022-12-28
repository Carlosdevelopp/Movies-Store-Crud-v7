using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;

namespace Infrastructure.Implementation
{
    public class MoviesInfrastructure : IMoviesInfrastructure
    {
        private readonly IMoviesDataAccess _moviesDA;

        public MoviesInfrastructure(IMoviesDataAccess moviesDataAccess)
        {
            _moviesDA = moviesDataAccess;
        }

        #region GET
        //Get a record
        public Movies GetMovie(int movieId)
        {
            Movies movie = _moviesDA.GetMovie(movieId); 

            return movie;   
        }

        //Traer todos los registros
        public List<Movies> GetMovies()
        {
            List<Movies> Movies = _moviesDA.GetMovies();

            List<Movies> movies = (from u in Movies
                                         select new Movies
                                         {
                                             Description = u.Description,
                                             Title = u.Title,
                                             Release = u.Release,
                                             RunningTime = u.RunningTime,
                                         }).ToList();

            return movies;
        }

        #endregion

        #region POST

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
