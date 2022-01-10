using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieRESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieDAL movieDAL = new MovieDAL();

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return movieDAL.GetAllMovies();
        }

        [HttpGet("category/{category}")]
        public List<Movie> GetMovieByCategory(string category)
        {
            return movieDAL.GetMovieByCategory(category);
        }

        [HttpGet("Random")]
        public Movie GetRandomMovie()
        {
            return movieDAL.GetRandomMovie();
        }

        [HttpGet("Random/{category}")]
        public Movie GetRandomMovieByCategory(string category)
        {
            return movieDAL.GetRandomMovieByCategory(category);
        }




    }
}
