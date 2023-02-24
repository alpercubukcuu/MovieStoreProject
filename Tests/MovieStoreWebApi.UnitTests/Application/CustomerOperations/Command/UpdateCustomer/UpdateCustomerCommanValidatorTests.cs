using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.UpdateCustomer;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CustomerOperations.Commands.Customer
{
    public class CustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public CustomerCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData("asdf", "asdf" ,"asdf", "asdf")]
        [InlineData("asd ", "asd " ,"asd ", "asd ")]
        [InlineData(" asd", " asd" ," asd", " asd")]
        [InlineData(" a  ", "as  " ," da  ", "asd ")]
        [InlineData("asdf ", "aa  " ,"a   ", "d   ")]
        [InlineData(" dasd", " sasd " ,"  asdd", " sasd ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname, string email, string password)
        {
            //arrange
            UpdateCustomerCommand command = new UpdateCustomerCommand(null);
            command.Model = new UpdateCustomerModel(){ FirstName = firstname, LastName=lastname, Email = email, Password = password };
            //act
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }
        
        [Theory]
        [InlineData(1,"asdf", "asdf" ,"asdf", "123456")]
        [InlineData(2,"asd ", "asd " ,"asd ", "123456")]
        [InlineData(3," asd", " asd" ," asd", "123456")]
        [InlineData(4," a  ", "as  " ," da  ", "123456")]
        [InlineData(5,"asdf ", "aa  " ,"a   ", "123456")]
        [InlineData(6," dasd", " sasd " ,"  asdd", "123456")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int customerid, string firstname, string lastname, string email, string password)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(null);
            command.Model = new UpdateCustomerModel()
            {
                FirstName = firstname,
                LastName =  lastname,
                Email = email,
                Password = password     
            };
            command.CustomerId= customerid;

            UpdateCustomerCommandValidator validations=new UpdateCustomerCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

      
    }

}