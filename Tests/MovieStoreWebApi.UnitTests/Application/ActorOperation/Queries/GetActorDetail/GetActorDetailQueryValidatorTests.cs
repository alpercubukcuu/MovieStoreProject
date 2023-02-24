using FluentAssertions;
using MovieStoreWebApi.ActorOperations.GetActorDetail;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidActoridIsGiven_Validator_ShouldBeReturnErrors(int actorid)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null,null);
            query.ActorId=actorid;

            GetActorDetailQeuryValidator validator = new GetActorDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidActoridIsGiven_Validator_ShouldNotBeReturnErrors(int actorid)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null,null);
            query.ActorId=actorid;

            GetActorDetailQeuryValidator validator = new GetActorDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}