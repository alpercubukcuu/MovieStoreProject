using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.OrderOperations.GetOrderDetail;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.OrderOperations.Queries
{
    public class GetOrderDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenOrderIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetOrderDetailQuery command = new GetOrderDetailQuery(_context,_mapper);
            command.OrderId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Sipariş bulunamadı ...");
        }

        [Fact]
        public void WhenGivenOrderIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetOrderDetailQuery command = new GetOrderDetailQuery(_context,_mapper);
            command.OrderId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var order=_context.Orders.SingleOrDefault(order=>order.Id == command.OrderId);
            order.Should().NotBeNull();
        }
    }
}