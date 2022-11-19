using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //Obtener todos los registros
        public List<Movies> GetMovies()
        {
            List<Movies> movies = (from m in _dbContext.Movies
                                   select m).ToList();

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
