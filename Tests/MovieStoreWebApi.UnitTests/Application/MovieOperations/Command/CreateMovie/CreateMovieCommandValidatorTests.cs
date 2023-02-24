using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.CreateMovie;
using MovieStoreWebApi.MovieOperations.CreateMovie;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.MovieOperations.CreateMovie.CreateMovieCommand;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(" "," ", 0, 50)]
        [InlineData("a "," s", 1, 0)]
        [InlineData("as "," as", 1, 25)]
        [InlineData("a "," s", 1, 0)]
        [InlineData("asd","dsa", 0, 125)]
        [InlineData("ds","as", 1, 150)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title, string release_year, int categoryid, int price)
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel(){Title = title, Release_year = release_year, CategoryId = categoryid, Price=price};
            
            //act
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf","asdf", 1, 200)]
        [InlineData("asa "," sas", 2, 50)]
        [InlineData("asadf "," asdasdas", 1, 500)]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string title, string release_year, int categoryid, int price)
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel(){Title = title, Release_year = release_year, CategoryId = categoryid, Price=price};
            
            //act
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}