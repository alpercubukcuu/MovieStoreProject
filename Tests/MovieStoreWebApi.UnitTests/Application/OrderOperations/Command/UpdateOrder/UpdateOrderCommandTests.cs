
using FluentAssertions;
using MovieStoreWebApi.OrderOperations.UpdateOrder;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateOrderCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistOrderIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateOrderCommand command = new UpdateOrderCommand(_context,null);
            command.OrderId = 0;

            UpdateOrderModel model = new UpdateOrderModel(){CustomerId=1, MovieId=1};            
            command.Model = model;
            

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Sipariş bulunamadı ...");

        }

        [Fact]
        public void WhenAlreadyExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateOrderCommand command = new UpdateOrderCommand(_context,null);
            command.OrderId = 1;

            UpdateOrderModel model = new UpdateOrderModel(){CustomerId=0, MovieId=1};            
            command.Model = model;
            

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri bulunamadı!");

        }

        [Fact]
        public void WhenAlreadyExistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateOrderCommand command = new UpdateOrderCommand(_context,null);
            command.OrderId = 1;

            UpdateOrderModel model = new UpdateOrderModel(){CustomerId=1, MovieId=0};            
            command.Model = model;
            

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film bulunamadı!");

        }

        [Fact]
        public void WhenGivenOrderIdinDB_Order_ShouldBeUpdate()
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context,null);

            UpdateOrderModel model = new UpdateOrderModel(){CustomerId=1, MovieId=1};            
            command.Model = model;
            command.OrderId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var order =_context.Categories.SingleOrDefault(order=>order.Id == command.OrderId);
            order.Should().NotBeNull();
            
        }
    }

}