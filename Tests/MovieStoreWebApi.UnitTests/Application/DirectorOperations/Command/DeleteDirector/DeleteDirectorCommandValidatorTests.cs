
using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.DeleteDirector;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidDirectorIdIsGiven_Validator_ShouldBeReturnErrors(int directorid)
        {
            //arrange
            DeleteDirectorCommand command = new DeleteDirectorCommand(null!);
            command.DirectorId = directorid;
            
            //act
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int directorid)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(null!);
            command.DirectorId = directorid;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}