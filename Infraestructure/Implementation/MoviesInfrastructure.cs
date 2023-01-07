using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Utils;

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
        public MoviesDTO GetMovie(int movieId)
        {
            Movies movie = _moviesDA.GetMovie(movieId);

            MoviesDTO movieDTO = new MoviesDTO();
            {
                movieDTO.TitleMovie = movie.Title.TitleFormat();
                movieDTO.DescriptionMovie = movie.Description.TextUpperCase();
                movieDTO.ReleaseMovie = movie.Release;
                movieDTO.RunningMovie = movie.RunningTime;
            }

            return movieDTO;   
        }

        //Traer todos los registros
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> Movies = _moviesDA.GetMovies();

            //Sintaxis
            //List<MoviesDTO> movies = (from u in Movies
            //                             select new MoviesDTO
            //                             {
            //                                 TitleMovie = u.Title,
            //                                 DescriptionMovie = u.Description,
            //                                 ReleaseMovie = u.Release,
            //                                 RunningMovie = u.RunningTime,
            //                             }).ToList();


            //Method
            List<MoviesDTO> _movies = Movies.Select(u => new MoviesDTO
            {
                DescriptionMovie = u.Description,
                TitleMovie = u.Title,
                ReleaseMovie = u.Release,
                RunningMovie = u.RunningTime,
            }).ToList();

            return _movies;
        }

        //Get a record MovieDetails
        public AwardsDTO GetMovieDetails(int MovieId)
        {
            Movies movie = _moviesDA.GetMovieDetails(MovieId);

            AwardsDTO awardsDTO = new AwardsDTO()
            {
                TitleMovie = movie.Title,
                DescriptionMovie = movie.Description,
                ReleaseMovie = movie.Release.ToShortDate(),
                RunningTimeMovie = movie.RunningTime.FormatTime(),
                Genre = movie.Genres.Genre.ToLower(),
                Award = movie.Awards.AwardTitle.AwardText(),
                
            };

            return awardsDTO;
        }

        //Get all records MoviesDetails
        public List<AwardsDTO> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDA.GetMoviesDetails();

            //Sintaxis
            //List<AwardsDTO> awardsDTO = (from u in movies
            //                             select new AwardsDTO
            //                             {
            //                                 TitleMovie= u.Title,
            //                                 DescriptionMovie = u.Description,  
            //                                 ReleaseMovie = u.Release,  
            //                                 RunningTimeMovie = u.RunningTime,
            //                             }).ToList();



            //Method
            List<AwardsDTO> awardsDTO = movies.Select(u => new AwardsDTO
            {
                TitleMovie = u.Title.TitleFormat(),
                DescriptionMovie = u.Description.TextUpperCase(),
                ReleaseMovie = u.Release.ToShortDate(),
                RunningTimeMovie = u.RunningTime.FormatTime(),
                Genre = u.Genres.Genre.ToLower(),
                Award = u.Awards.AwardTitle.AwardText(),
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
