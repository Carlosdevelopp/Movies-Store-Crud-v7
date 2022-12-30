using DataAccess.Models.Tables;

namespace DataAccess.Contract
{
    public interface IMoviesDataAccess
    {
        #region GET
        Movies GetMovie(int movieId);
        List<Movies> GetMovies();
        #endregion

        #region POST
        void InsertMovie(Movies movie);
        #endregion

        #region PUT

        #endregion

        #region DELETE
        void DeleteMovie(int movieId);
        #endregion
    }
}
