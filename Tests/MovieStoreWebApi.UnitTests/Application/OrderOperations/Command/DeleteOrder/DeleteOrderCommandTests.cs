


using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.OrderOperations.DeleteOrder;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
       

        public DeleteOrderCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenOrderIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek sipariş bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Order_ShouldBeCreated()
        {
            //arrange
           var order = new Order() {CustomerId=1, MovieId =2};
           _context.Add(order);
           _context.SaveChanges();

           DeleteOrderCommand command = new DeleteOrderCommand(_context);
           command.OrderId = order.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            order = _context.Orders.SingleOrDefault(x=> x.Id == order.Id);
            order.Should().BeNull();

        }
    }

}