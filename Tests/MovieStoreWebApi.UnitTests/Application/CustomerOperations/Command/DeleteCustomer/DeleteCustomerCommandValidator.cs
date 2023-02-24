
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.DeleteCustomer;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidCustomerIdIsGiven_Validator_ShouldBeReturnErrors(int customerid)
        {
            //arrange
            DeleteCustomerCommand command = new DeleteCustomerCommand(null!);
            command.CustomerId = customerid;
            
            //act
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int customerid)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null!);
            command.CustomerId = customerid;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}