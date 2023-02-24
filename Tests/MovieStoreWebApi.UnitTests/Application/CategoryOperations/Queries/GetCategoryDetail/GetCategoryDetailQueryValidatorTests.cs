using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.GetCategoryDetail;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CategoryOperations.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidCategoryidIsGiven_Validator_ShouldBeReturnErrors(int categoryid)
        {
            GetCategoryDetailQuery query = new GetCategoryDetailQuery(null,null);
            query.CategoryId=categoryid;

            GetCategoryDetailQeuryValidator validator = new GetCategoryDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidCategoryidIsGiven_Validator_ShouldNotBeReturnErrors(int categoryid)
        {
            GetCategoryDetailQuery query = new GetCategoryDetailQuery(null,null);
            query.CategoryId=categoryid;

            GetCategoryDetailQeuryValidator validator = new GetCategoryDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}