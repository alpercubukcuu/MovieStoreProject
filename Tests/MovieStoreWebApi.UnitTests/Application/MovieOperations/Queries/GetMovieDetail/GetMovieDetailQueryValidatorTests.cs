using FluentAssertions;
using MovieStoreWebApi.MovieOperations.GetMovieDetail;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidMovieidIsGiven_Validator_ShouldBeReturnErrors(int movieid)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(null,null);
            query.MovieId=movieid;

            GetMovieDetailQeuryValidator validator = new GetMovieDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidMovieidIsGiven_Validator_ShouldNotBeReturnErrors(int movieid)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(null,null);
            query.MovieId=movieid;

            GetMovieDetailQeuryValidator validator = new GetMovieDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}