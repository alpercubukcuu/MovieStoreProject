using FluentAssertions;
using MovieStoreWebApi.OrderOperations.CreateOrder;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.OrderOperations.CreateOrder.CreateOrderCommand;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0 )]
        [InlineData(0, 1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int customerid, int movieid)
        {
            //arrange
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = new CreateOrderModel(){CustomerId = customerid, MovieId = movieid};
            
            //act
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(200, 20 )]
        [InlineData(5,5)]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(int customerid, int movieid)
        {
            //arrange
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = new CreateOrderModel(){CustomerId = customerid, MovieId = movieid};
            
            //act
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}