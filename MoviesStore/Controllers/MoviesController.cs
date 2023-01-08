using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MoviesStore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInfrastructure _moviesInfrastructure;

        public MoviesController(IMoviesInfrastructure moviesInfrastructure)
        {
            _moviesInfrastructure = moviesInfrastructure;
        }

        #region GET
        /// <summary>
        /// Get a record by id
        /// </summary>
        /// <param name="movieId">Integer with id movie</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     GET /An
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "runningMovie": 0,
        ///       "releaseMovie": "yyyy-MM-dd",
        ///       "genre": 0,
        ///       "award": 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">An error ocurred on the server</response>
        [HttpGet("GetMovie")]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovie(movieId));
            }
            catch (Exception)
            {
                return BadRequest("server internal error");
            }
        }

        /// <summary>
        /// Get movie list
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     GET /All
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "runningMovie": 0,
        ///       "releaseMovie": "yyyy-MM-dd",
        ///       "genre": 0,
        ///       "award": 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">An error ocurred on the server</response>
        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovies());
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }

        /// <summary>
        /// Get movieDetails by id
        /// </summary>
        /// <param name="movieId">Integer with id movie</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     GET /An
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseMovie": "dd/MM/yyyy",
        ///       "runningTimeMovie": "0",
        ///       "genre": "string",
        ///       "award": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">An error ocurred on the server</response>
        [HttpGet("GetMovieDetails")]
        public IActionResult GetMovieDetails(int movieId)
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovieDetails(movieId));
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }

        /// <summary>
        /// Get moviesDetails
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     GET /All
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseMovie": "dd/MM/yyyy",
        ///       "runningTimeMovie": "0",
        ///       "genre": "string",
        ///       "award": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">An error ocurred on the server</response>
        [HttpGet("GetMoviesDetails")]
        public IActionResult GetMoviesDetails()
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMoviesDetails());
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }
        #endregion

        #region POST
        /// <summary>
        /// Insert a record 
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /An
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseMovie": "yyyy-MM-dd",
        ///       "runningTimeMovie": 0,
        ///       "genreId": 0,
        ///       "awardId": 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">An error ocurred on the server</response>
        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie(MoviesInsertDTO movie)
        {
            try
            {
                _moviesInfrastructure.InsertMovie(movie);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Update a record 
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     PUT /An
        ///     {
        ///       "movieId": 0,
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseMovie": "yyyy-MM-dd",
        ///       "runningMovie": 0,
        ///       "genre": 0,
        ///       "award": 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">An error ocurred on the server</response>
        [HttpPut("UpdateMovie")]
        public IActionResult InsertMovie(MoviesUpdateDTO movie)
        {
            try
            {
                 _moviesInfrastructure.UpdateMovie(movie);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete a record 
        /// </summary>
        /// <response code="200">Successful operation</response>
        /// <response code="400">An error ocurred on the server</response>
        /// <returns></returns>
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            try
            {
                _moviesInfrastructure.DeleteMovie(movieId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }
        #endregion
    }
}
