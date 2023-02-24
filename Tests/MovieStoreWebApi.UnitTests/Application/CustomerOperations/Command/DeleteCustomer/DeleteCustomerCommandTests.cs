


using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.DeleteCustomer;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;
using MovieStoreWebApi.Entities;

namespace Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
       

        public DeleteCustomerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenCustomerIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek müşteri bulunamadı ...");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeCreated()
        {
            //arrange
           var customer = new Customer() {FirstName="asdf", LastName="FSAD", Email="ASDFFASD@mail.com", Password="123456"};
           _context.Add(customer);
           _context.SaveChanges();

           DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
           command.CustomerId = customer.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            customer = _context.Customers.SingleOrDefault(x=> x.Id == customer.Id);
            customer.Should().BeNull();

        }
    }

}