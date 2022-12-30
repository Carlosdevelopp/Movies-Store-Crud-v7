using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;

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
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> Movies = _moviesDA.GetMovies();

            List<MoviesDTO> movies = (from u in Movies
                                         select new MoviesDTO
                                         {
                                             DescriptionMovie = u.Description,
                                             TitleMovie = u.Title,
                                             ReleaseMovie = u.Release,
                                             RunningMovie = u.RunningTime,
                                         }).ToList();

            return movies;
        }

        #endregion

        #region POST
        public void InsertMovies(MoviesInsertDTO moviesInsertDTO)
        {
            Movies movie = new();
            {
                movie.Title = moviesInsertDTO.TitleMovie;
                movie.Description = moviesInsertDTO.DescriptionMovie;
                movie.Release = moviesInsertDTO.ReleaseMovie;
                movie.RunningTime = moviesInsertDTO.RunningTimeMovie;
                movie.GenreId = moviesInsertDTO.GenreId;
                movie.AwardId = moviesInsertDTO.AwardId;
            }
            _moviesDA.InsertMovie(movie);  
            
        }
        #endregion

        #region PUT
        #endregion

        #region DELETE
        public void DeleteMovie(int movieId)
        {
            _moviesDA.DeleteMovie(movieId);
        }
        #endregion
    }
}
