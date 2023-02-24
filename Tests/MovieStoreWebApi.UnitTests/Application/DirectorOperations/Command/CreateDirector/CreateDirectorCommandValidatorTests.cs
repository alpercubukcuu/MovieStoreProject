using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.CreateDirector;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.DirectorOperations.CreateDirector.CreateDirectorCommand;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(" ", " ")]
        [InlineData(" ", "asd" )]
        [InlineData("asd", " " )]
        [InlineData("as", "a" )]
        [InlineData("a", "sa" )]
        [InlineData("aaa", "saa" )]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname)
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel(){FirstName = firstname, LastName = lastname};
            
            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf ", " asdf")]
        [InlineData("asdf", "asdf" )]
        [InlineData("as  ", "sa  " )]
        [InlineData(" as ", " a  " )]
        [InlineData("asdadasdasd", "asdasdasdasdas" )]
        [InlineData(" aaa", "saa " )]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname)
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel(){FirstName = firstname, LastName = lastname};
            
            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}