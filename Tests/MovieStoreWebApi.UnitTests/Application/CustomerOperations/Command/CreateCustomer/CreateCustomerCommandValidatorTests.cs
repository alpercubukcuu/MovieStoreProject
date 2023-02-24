using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.CreateCustomer;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.CustomerOperations.CreateCustomer.CreateCustomerCommand;

namespace MovieStoreWebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData("asd", "asd" ,"asd", "asd")]
        [InlineData(" ", " " ," ", " ")]
        [InlineData("a ", " s" ,"  s", "d  ")]
        [InlineData(" a ", "as " ," da", " ")]
        [InlineData("asdf ", "aa " ,"a ", "d ")]
        [InlineData(" d", " s " ,"  d", " s ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname, string email, string password)
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel(){FirstName=firstname, LastName=lastname, Email="email", Password=password};
            
            //act
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf", "asdf" ,"asdf", "123456")]
        [InlineData("asd ", "asd " ,"asd ", "123456")]
        [InlineData(" asdf", " asdf" ," asdf", "123456")]
        [InlineData("sdfasd", "asdfasd" ,"dasdadssa", "123456")]
        [InlineData("asdf ", "aa  " ,"a   ", "123456")]
        [InlineData(" dasd", " sasd " ,"  asdd", "123456")]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname, string email, string password)
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel(){FirstName = firstname, LastName=lastname, Email = email, Password = password };
            
            //act
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}