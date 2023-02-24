
using FluentAssertions;
using MovieStoreWebApi.OrderOperations.DeleteOrder;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidOrderIdIsGiven_Validator_ShouldBeReturnErrors(int orderid)
        {
            //arrange
            DeleteOrderCommand command = new DeleteOrderCommand(null!);
            command.OrderId = orderid;
            
            //act
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int orderid)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(null!);
            command.OrderId = orderid;

            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}