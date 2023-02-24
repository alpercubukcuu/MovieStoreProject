using FluentAssertions;
using MovieStoreWebApi.OrderOperations.GetOrderDetail;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidOrderidIsGiven_Validator_ShouldBeReturnErrors(int orderid)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(null,null);
            query.OrderId=orderid;

            GetOrderDetailQeuryValidator validator = new GetOrderDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidOrderidIsGiven_Validator_ShouldNotBeReturnErrors(int orderid)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(null,null);
            query.OrderId=orderid;

            GetOrderDetailQeuryValidator validator = new GetOrderDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}