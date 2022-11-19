using Infraestructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MoviesStore.Controllers
{
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInfraestructure _moviesInfraestructure;

        public MoviesController(IMoviesInfraestructure moviesInfraestructure)
        {
            _moviesInfraestructure = moviesInfraestructure;
        }

        #region GET
        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            try
            {
                return Ok(_moviesInfraestructure.GetMovies());
            }
            catch (System.Exception)
            {
                return BadRequest("Server internal error");
            }
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
