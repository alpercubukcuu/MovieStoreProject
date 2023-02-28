
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.OrderOperations.Queries;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.OrderOperations.CreateOrder;
using MovieStoreWebApi.OrderOperations.DeleteOrder;
using MovieStoreWebApi.OrderOperations.GetOrderDetail;
using MovieStoreWebApi.OrderOperations.UpdateOrder;
using static MovieStoreWebApi.OrderOperations.CreateOrder.CreateOrderCommand;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]    
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            GetOrderQuery query = new GetOrderQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_dbContext, _mapper);
            query.OrderId = id;

            GetOrderDetailQeuryValidator validator = new GetOrderDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreatePurchasedMovie([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
            command.Model = model;

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id,[FromBody] UpdateOrderModel updateorder)
        {
            UpdateOrderCommand command = new UpdateOrderCommand( _dbContext,null);
            command.OrderId = id;

            command.Model = updateorder;
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

       [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
                DeleteOrderCommand command = new DeleteOrderCommand(_dbContext);
                command.OrderId = id;
                DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }
    }
}
