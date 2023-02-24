using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using static MovieStoreWebApi.ActorOperations.CreateActor.CreateActorCommand;
using MovieStoreWebApi.ActorOperations.CreateActor;
using MovieStoreWebApi.Application.ActorOperations.Queries;
using MovieStoreWebApi.ActorOperations.GetActorDetail;
using MovieStoreWebApi.ActorOperations.UpdateActor;
using MovieStoreWebApi.ActorOperations.DeleteActor;
using Microsoft.AspNetCore.Authorization;
using static MovieStoreWebApi.ActorOperations.UpdateActor.UpdateActorCommand;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public ActorController(IMovieStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetActor()
        {
           GetActorQuery query = new GetActorQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ActorDetailViewModel result;
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.ActorId= id;
            GetActorDetailQeuryValidator validator = new GetActorDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel newactor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            var actor = _context.Actors.SingleOrDefault(x=> x.FirstName == newactor.FirstName && x.LastName == newactor.LastName);
           
                command.Model = newactor;
                CreateActorCommandValidator validator = new CreateActorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

       

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id,[FromBody] UpdateActorModel updateactor)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = id;

            command.Model = updateactor;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
                DeleteActorCommand command = new DeleteActorCommand(_context);
                command.ActorId = id;
                DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }
    }
}