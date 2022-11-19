using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infraestructure.Contract;
using Infraestructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Implementation
{
    public class MoviesInfraestructure : IMoviesInfraestructure
    {
        private readonly IMoviesDataAccess _moviesDA;

        public MoviesInfraestructure(IMoviesDataAccess moviesDataAccess)
        {
            _moviesDA = moviesDataAccess;
        }

        #region GET
        //Traer todos los registros
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> movies = _moviesDA.GetMovies();

            List<MoviesDTO> moviesDTO = (from m in movies
                                         select new MoviesDTO
                                         {
                                             DescriptionMovie = m.Description,
                                             TitleMovie = m.Title,
                                             ReleaseMovie = m.Release,
                                             RunningTimeMovie = m.RunningTime,
                                         }).ToList();

            return moviesDTO;
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
