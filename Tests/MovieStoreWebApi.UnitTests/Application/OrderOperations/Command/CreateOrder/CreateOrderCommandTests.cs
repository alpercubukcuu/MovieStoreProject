using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.OrderOperations.CreateOrder;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.OrderOperations.CreateOrder.CreateOrderCommand;

namespace MovieStoreWebApi.Application.OrderOperations.Command.CreateOrder
{
    public class CreateOrderCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistOrderCustomerIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            
           
            var order = new Order() {CustomerId=200, MovieId=1};
            _context.Orders.Add(order);
            _context.SaveChanges();

            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() {CustomerId = order.CustomerId, MovieId = order.MovieId};
            var customer = _context.Customers.SingleOrDefault(s => s.Id == order.CustomerId);
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri bulunamadı!");

        }

        [Fact]
        public void WhenAlreadyExistOrderMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            
           
            var order = new Order() {CustomerId=1, MovieId=200};
            _context.Orders.Add(order);
            _context.SaveChanges();

            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() {CustomerId = order.CustomerId, MovieId = order.MovieId};
            var customer = _context.Customers.SingleOrDefault(s => s.Id == order.CustomerId);
            var movies = _context.Movies.SingleOrDefault(s => s.Id == order.MovieId);
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film bulunamadı!");

        }



        
        [Fact]
        public void WhenValidInputsAreGiven_Order_ShouldBeCreated()
        {
            //arrange
            CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
            CreateOrderModel model = new CreateOrderModel() {CustomerId=1, MovieId=2 };
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var order = _context.Orders.SingleOrDefault(order => order.CustomerId == model.CustomerId && order.MovieId == model.MovieId);
            order.Should().NotBeNull();
            
        }
        
    }
}