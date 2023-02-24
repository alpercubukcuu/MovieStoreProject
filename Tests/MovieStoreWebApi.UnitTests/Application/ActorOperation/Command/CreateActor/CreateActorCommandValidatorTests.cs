using FluentAssertions;
using MovieStoreWebApi.ActorOperations.CreateActor;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.ActorOperations.CreateActor.CreateActorCommand;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
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
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel(){FirstName = firstname, LastName = lastname};
            
            //act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
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
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel(){FirstName = firstname, LastName = lastname};
            
            //act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}