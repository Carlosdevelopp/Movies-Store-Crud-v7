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
