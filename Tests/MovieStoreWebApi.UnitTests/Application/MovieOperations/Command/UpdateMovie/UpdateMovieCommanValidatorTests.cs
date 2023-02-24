using FluentAssertions;
using MovieStoreWebApi.MovieOperations.UpdateMovie;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateMovieCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0," "," ", 0, 50)]
        [InlineData(1,"a "," s", 1, 0)]
        [InlineData(200,"as "," as", 1, 25)]
        [InlineData(0,"a "," s", 1, 0)]
        [InlineData(0,"asd","dsa", 0, 125)]
        [InlineData(0,"ds","as", 1, 150)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int movieid,string title, string release_year, int categoryid, int price)
        {
            //arrange
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Model = new UpdateMovieModel(){Title = title, Release_year = release_year, CategoryId = categoryid, Price = price};
            command.MovieId=movieid;
            //act
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(1,"asdf","asdf", 1, 200)]
        [InlineData(200,"asa "," sas", 2, 50)]
        [InlineData(40,"asadf "," asdasdas", 1, 500)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int movieid,string title, string release_year, int categoryid, int price)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Model = new UpdateMovieModel()
            {
               Title = title, Release_year = release_year, CategoryId = categoryid, Price = price         
            };
            command.MovieId=movieid;

            UpdateMovieCommandValidator validations=new UpdateMovieCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

      
    }

}