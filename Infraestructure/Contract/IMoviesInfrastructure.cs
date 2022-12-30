using DataAccess.Models.Tables;
using Infrastructure.DTO;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        Movies GetMovie(int movieId);
        List<MoviesDTO> GetMovies();
        #endregion

        #region POST
        void InsertMovies(MoviesInsertDTO moviesInsertDTO);
        #endregion

        #region PUT

        #endregion

        #region DELETE
        void DeleteMovie(int movieId);
        #endregion
    }
}
