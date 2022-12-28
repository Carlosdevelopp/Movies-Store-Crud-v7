using DataAccess.Models.Tables;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        Movies GetMovie(int movieId);
        List<Movies> GetMovies();
        #endregion

        #region POST

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
