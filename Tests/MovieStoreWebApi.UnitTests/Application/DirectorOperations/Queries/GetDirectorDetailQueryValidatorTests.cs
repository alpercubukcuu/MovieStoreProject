using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.GetDirectorDetail;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidDirectoridIsGiven_Validator_ShouldBeReturnErrors(int directorid)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null,null);
            query.DirectorId=directorid;

            GetDirectorDetailQeuryValidator validator = new GetDirectorDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidDirectoridIsGiven_Validator_ShouldNotBeReturnErrors(int directorid)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null,null);
            query.DirectorId=directorid;

            GetDirectorDetailQeuryValidator validator = new GetDirectorDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}