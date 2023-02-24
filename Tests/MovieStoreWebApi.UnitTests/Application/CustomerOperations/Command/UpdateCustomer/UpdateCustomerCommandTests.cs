
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.UpdateCustomer;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateCustomerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.CustomerId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek müşteri bulunamadı...");

        }

        [Fact]
        public void WhenGivenCustomerIdinDB_Customer_ShouldBeUpdate()
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);

            UpdateCustomerModel model = new UpdateCustomerModel(){FirstName="asdf", LastName="FSAD", Email="ASDFFASD@mail.com", Password="123456"};            
            command.Model = model;
            command.CustomerId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var customer =_context.Customers.SingleOrDefault(customer=>customer.Id == command.CustomerId);
            customer.Should().NotBeNull();
            
        }
    }

}