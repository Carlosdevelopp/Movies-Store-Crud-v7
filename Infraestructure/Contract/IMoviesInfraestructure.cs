using DataAccess.Models.Tables;
using Infraestructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Contract
{
    public interface IMoviesInfraestructure
    {
        #region GET
        List<MoviesDTO> GetMovies();
        #endregion

        #region POST

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
