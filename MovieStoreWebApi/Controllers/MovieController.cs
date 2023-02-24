using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.CustomerOperations.CreateCustomer;
using static MovieStoreWebApi.CustomerOperations.CreateCustomer.CreateCustomerCommand;
using MovieStoreWebApi.Application.MovieOperations.Queries;
using MovieStoreWebApi.MovieOperations.GetMovieDetail;
using MovieStoreWebApi.MovieOperations.UpdateMovie;
using MovieStoreWebApi.MovieOperations.DeleteMovie;
using static MovieStoreWebApi.MovieOperations.CreateMovie.CreateMovieCommand;
using MovieStoreWebApi.MovieOperations.CreateMovie;
using MovieStoreWebApi.CustomerOperations.CreateMovie;
using Microsoft.AspNetCore.Authorization;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public MovieController(IMovieStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetMovie()
        {
           GetMovieQuery query = new GetMovieQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieDetailViewModel result;
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = id;
            GetMovieDetailQeuryValidator validator = new GetMovieDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieModel newmovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            var movie = _context.Movies.SingleOrDefault(x=> x.Title == newmovie.Title);
           
                command.Model = newmovie;
                CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id,[FromBody] UpdateMovieModel updatemovie)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = id;

            command.Model = updatemovie;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.MovieId = id;
                DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }
    }
}