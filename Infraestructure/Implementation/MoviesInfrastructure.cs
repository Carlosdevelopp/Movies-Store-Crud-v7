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

        //Get a record MovieDetails
        public AwardsDTO GetMovieDetails(int MovieId)
        {
            Movies movie = _moviesDA.GetMovieDetails(MovieId);

            AwardsDTO awardsDTO = new AwardsDTO()
            {
                TitleMovie = movie.Title,
                DescriptionMovie = movie.Description,
                ReleaseMovie = movie.Release,
                RunningTimeMovie = movie.RunningTime,
            };

            return awardsDTO;
        }

        //Get all records MoviesDetails
        public List<AwardsDTO> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDA.GetMoviesDetails();

            List<AwardsDTO> awardsDTO = (from u in movies
                                         select new AwardsDTO
                                         {
                                             TitleMovie= u.Title,
                                             DescriptionMovie = u.Description,  
                                             ReleaseMovie = u.Release,  
                                             RunningTimeMovie = u.RunningTime,
                                         }).ToList();

            return awardsDTO;
        }
        #endregion

        #region POST
        public void InsertMovie(MoviesInsertDTO moviesInsertDTO)
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
        public void UpdateMovie(MoviesUpdateDTO movie)
        {
            Movies _movie = new();
            {
                _movie.MovieId = movie.MovieId;
                _movie.Title = movie.TitleMovie;
                _movie.Description = movie.DescriptionMovie;
                _movie.Release = movie.ReleaseMovie;
                _movie.RunningTime = movie.RunningTimeMovie;
                _movie.GenreId = movie.GenreId;
                _movie.AwardId = movie.AwardId;

                _moviesDA.UpdateMovie(_movie);
            }
        }
        #endregion

        #region DELETE
        public void DeleteMovie(int movieId)
        {
            _moviesDA.DeleteMovie(movieId);
        }
        #endregion
    }
}
