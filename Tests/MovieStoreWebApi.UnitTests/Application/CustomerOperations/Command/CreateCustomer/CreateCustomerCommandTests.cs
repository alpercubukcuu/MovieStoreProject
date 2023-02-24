using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.CreateCustomer;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.CustomerOperations.CreateCustomer.CreateCustomerCommand;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.CreateCustomer
{
    public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistCustomerIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var customer = new Customer() {FirstName="asdf", LastName="FSAD", Email="ASDFFASD@mail.com", Password="123456"};
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = new CreateCustomerModel() {FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Password = customer.Password};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri zaten mevcut ...");

        }



        
       [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeCreated()
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
            CreateCustomerModel model = new CreateCustomerModel() {FirstName="asdf", LastName="FSAD", Email="ASDFFASD@mail.com", Password="123456"};
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var customer = _context.Customers.SingleOrDefault(category => category.Email == model.Email);
            customer.Should().NotBeNull();
        }

        
    }
}