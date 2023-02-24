


using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.DeleteCategory;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;
using MovieStoreWebApi.Entities;

namespace Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
       

        public DeleteCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenCategoryIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteCategoryCommand command = new DeleteCategoryCommand(_context);
            command.CategoryId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kategori bulunamadı ...");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeCreated()
        {
            //arrange
           var category = new Category() {CategoryName="WhenValidInputsAreGiven_Category_ShouldBeCreated"};
           _context.Add(category);
           _context.SaveChanges();

           DeleteCategoryCommand command = new DeleteCategoryCommand(_context);
           command.CategoryId = category.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            category = _context.Categories.SingleOrDefault(x=> x.Id == category.Id);
            category.Should().BeNull();

        }
    }

}