using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApiDTO.Enums;
using MoviesApiDTO.Models;
using MoviesApiSL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IValidationService _validationService;

        public MoviesController(IMoviesService moviesService, IValidationService validationService)
        {
            _moviesService = moviesService;
            _validationService = validationService;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Title",
            [FromQuery] string orderDirection = "Ascending")
        {

            try
            {
                ValidationDto pagingSortingValidation =
                    _validationService.ValidatePagingAndSorting(sortBy, orderDirection, page, pageSize);

                if (pagingSortingValidation.IsValid == false)
                {
                    return BadRequest(pagingSortingValidation.Message);
                }

                IEnumerable<MovieDto> movies = await _moviesService.GetAllMovies(page, pageSize, sortBy, orderDirection);
                if (movies.Any() == false)
                {
                    return NotFound("No movies have been found.");
                }

                return Ok(movies);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
                // TODO: Log the exception.
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(Guid id)
        {
            try
            {
                MovieDto? result = await _moviesService.GetMovieById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
                // TODO: Log the exception.
            }

        }

        // GET api/<MoviesController>/
        [HttpGet("title")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetByTitle(
            [FromQuery] string title,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Title",
            [FromQuery] string orderDirection = "Ascending")
        {
            try
            {
                ValidationDto pagingSortingValidation =
                    _validationService.ValidatePagingAndSorting(sortBy, orderDirection, page, pageSize);

                if (pagingSortingValidation.IsValid == false)
                {
                    return BadRequest(pagingSortingValidation.Message);
                }

                IEnumerable<MovieDto> movies = await _moviesService.GetMoviesByTitle(
                    title, page, pageSize, sortBy, orderDirection);

                if (movies.Any() == false)
                {
                    return NotFound($"Unable to find movies containing '{title}' in the title.");
                }

                return Ok(movies.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
                // TODO: Log the exception.
            }
        }

        // GET api/<MoviesController>/genre/
        [HttpGet("genre")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetByGenre(
            [FromQuery] string genre,
            [FromQuery] int page,
            [FromQuery] int pageSize,
            [FromQuery] string sortBy = "Title",
            [FromQuery] string orderDirection = "Ascending")
        {
            try
            {
                ValidationDto pagingSortingValidation =
                    _validationService.ValidatePagingAndSorting(sortBy, orderDirection, page, pageSize);

                if (pagingSortingValidation.IsValid == false)
                {
                    return BadRequest(pagingSortingValidation.Message);
                }

                ValidationDto genreValidation = _validationService.ValidateGenre(genre);
                if (genreValidation.IsValid == false)
                {
                    return BadRequest(genreValidation.Message);
                }

                IEnumerable<MovieDto> movies = await _moviesService.GetMoviesByGenre(
                    genre, page, pageSize, sortBy, orderDirection);

                if (movies.Any() == false)
                {
                    return NotFound($"Unable to find movies with a genre containing '{genre}'.");
                }

                return Ok(movies);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
                // TODO: Log the exception.
            }

        }
    }
}
