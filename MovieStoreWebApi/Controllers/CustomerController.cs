

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.CustomerOperations.Queries;
using MovieStoreWebApi.CustomerOperations.CreateToken;
using MovieStoreWebApi.CustomerOperations.DeleteCustomer;
using MovieStoreWebApi.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.CustomerOperations.RefreshToken;
using MovieStoreWebApi.CustomerOperations.UpdateCustomer;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.TokenOperations.Models;
using MovieStoreWebApi.CustomerOperations.CreateCustomer;
using static MovieStoreWebApi.CustomerOperations.CreateCustomer.CreateCustomerCommand;

namespace MovieStoreWebApi.Controllers
{
   
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CustomerController(IMovieStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
           GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CustomerDetailViewModel result;
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
            query.CustomerId = id;
            GetCustomerDetailQeuryValidator validator = new GetCustomerDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpGet("refreshToken")]
        
            public ActionResult<Token> RefreshToken([FromQuery] string token)
            {
                RefreshTokenCommand command = new RefreshTokenCommand(_context,_configuration);
                command.RefreshToken = token;
                var resultToken = command.Handle();
                return resultToken;
            }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerModel newcustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            var customer = _context.Customers.SingleOrDefault(x=> x.Email == newcustomer.Email);
           
                command.Model = newcustomer;
                CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;   
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id,[FromBody] UpdateCustomerModel updateuser)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.CustomerId = id;

            command.Model = updateuser;
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();       
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
                DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
                command.CustomerId = id;
                DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();        
        }

    }
}