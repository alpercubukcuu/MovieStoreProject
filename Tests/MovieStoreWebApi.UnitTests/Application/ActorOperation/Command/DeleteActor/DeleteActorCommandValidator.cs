
using FluentAssertions;
using MovieStoreWebApi.ActorOperations.DeleteActor;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidActorIdIsGiven_Validator_ShouldBeReturnErrors(int actorid)
        {
            //arrange
            DeleteActorCommand command = new DeleteActorCommand(null!);
            command.ActorId = actorid;
            
            //act
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int actorid)
        {
            DeleteActorCommand command = new DeleteActorCommand(null!);
            command.ActorId = actorid;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}