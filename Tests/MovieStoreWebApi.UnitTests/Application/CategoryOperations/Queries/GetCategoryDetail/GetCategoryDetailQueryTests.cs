using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.GetCategoryDetail;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CategoryOperations.Queries
{
    public class GetCategoryDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenCategoryIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetCategoryDetailQuery command = new GetCategoryDetailQuery(_context,_mapper);
            command.CategoryId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kategori bulunamadı...");
        }

        [Fact]
        public void WhenGivenCategoryIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetCategoryDetailQuery command = new GetCategoryDetailQuery(_context,_mapper);
            command.CategoryId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var category=_context.Categories.SingleOrDefault(category=>category.Id == command.CategoryId);
            category.Should().NotBeNull();
        }
    }
}