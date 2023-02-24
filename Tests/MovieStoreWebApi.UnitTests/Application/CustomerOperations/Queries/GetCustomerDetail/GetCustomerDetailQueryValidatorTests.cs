using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.GetCustomerDetail;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidCustomeridIsGiven_Validator_ShouldBeReturnErrors(int customerid)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(null,null);
            query.CustomerId=customerid;

            GetCustomerDetailQeuryValidator validator = new GetCustomerDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidCustomeridIsGiven_Validator_ShouldNotBeReturnErrors(int customerid)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(null,null);
            query.CustomerId=customerid;

            GetCustomerDetailQeuryValidator validator = new GetCustomerDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}