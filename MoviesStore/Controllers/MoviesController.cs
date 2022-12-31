﻿using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MoviesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInfrastructure _moviesInfrastructure;

        public MoviesController(IMoviesInfrastructure moviesInfrastructure)
        {
            _moviesInfrastructure = moviesInfrastructure;
        }

        #region GET
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
