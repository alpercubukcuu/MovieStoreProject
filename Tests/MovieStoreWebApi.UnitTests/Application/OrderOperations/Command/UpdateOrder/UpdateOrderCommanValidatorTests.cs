using FluentAssertions;
using MovieStoreWebApi.OrderOperations.UpdateOrder;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateOrderCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0,0,0)]
        [InlineData(0,1,0)]
        [InlineData(0,0,1)]
        [InlineData(-1,-1,-1)]
        [InlineData(1,-1,-1)]
        [InlineData(0,1,0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int orderid, int customerid, int movieid)
        {
            //arrange
            UpdateOrderCommand command = new UpdateOrderCommand(null,null);
            command.Model = new UpdateOrderModel(){ CustomerId=customerid, MovieId= movieid};
            command.OrderId=orderid;
            //act
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,1,1)]
        [InlineData(20,2,3)]
        [InlineData(200,200,300)]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int orderid, int customerid, int movieid)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(null,null);
            command.Model = new UpdateOrderModel()
            {
               CustomerId=customerid, MovieId= movieid             
            };
            command.OrderId=orderid;

            UpdateOrderCommandValidator validations=new UpdateOrderCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

      
    }

}