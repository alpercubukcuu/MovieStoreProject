using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using static MovieStoreWebApi.DirectorOperations.CreateDirector.CreateDirectorCommand;
using MovieStoreWebApi.DirectorOperations.CreateDirector;
using MovieStoreWebApi.DirectorOperations.GetDirectorDetail;
using MovieStoreWebApi.DirectorOperations.UpdateDirector;
using MovieStoreWebApi.DirectorOperations.DeleteDirector;
using DirectorStoreWebApi.Application.DirectorOperations.Queries;
using Microsoft.AspNetCore.Authorization;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public DirectorController(IMovieStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirector()
        {
           GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DirectorDetailViewModel result;
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId= id;
            GetDirectorDetailQeuryValidator validator = new GetDirectorDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDirectorModel newdirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            var director = _context.Directors.SingleOrDefault(x=> x.FirstName == newdirector.FirstName && x.LastName == newdirector.LastName);
           
                command.Model = newdirector;
                CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }
        

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id,[FromBody] UpdateDirectorModel updatedirector)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorId = id;

            command.Model = updatedirector;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
                DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
                command.DirectorId = id;
                DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }
    }
}