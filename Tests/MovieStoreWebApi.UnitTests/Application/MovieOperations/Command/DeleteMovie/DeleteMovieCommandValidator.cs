
using FluentAssertions;
using MovieStoreWebApi.MovieOperations.DeleteMovie;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidMovieIdIsGiven_Validator_ShouldBeReturnErrors(int movieid)
        {
            //arrange
            DeleteMovieCommand command = new DeleteMovieCommand(null!);
            command.MovieId = movieid;
            
            //act
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int movieid)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(null!);
            command.MovieId = movieid;

            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}