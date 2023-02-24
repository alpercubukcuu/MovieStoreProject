using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CustomerOperations.Queries
{
    public class GetCustomerDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenCustomerIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetCustomerDetailQuery command = new GetCustomerDetailQuery(_context,_mapper);
            command.CustomerId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kullanıcı bulunamadı...");
        }

        [Fact]
        public void WhenGivenCustomerIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetCustomerDetailQuery command = new GetCustomerDetailQuery(_context,_mapper);
            command.CustomerId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var customer=_context.Customers.SingleOrDefault(customer=>customer.Id == command.CustomerId);
            customer.Should().NotBeNull();
        }
    }
}