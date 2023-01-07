using DataAccess.Models.Tables;
using Infrastructure.DTO;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        MoviesDTO GetMovie(int movieId);
        List<MoviesDTO> GetMovies();
        AwardsDTO GetMovieDetails(int MovieId);
        List<AwardsDTO> GetMoviesDetails();
        #endregion

        #region POST
        void InsertMovie(MoviesInsertDTO moviesInsertDTO);
        #endregion

        #region PUT
        void UpdateMovie(MoviesUpdateDTO movie);
        #endregion

        #region DELETE
        void DeleteMovie(int movieId);
        #endregion
    }
}
