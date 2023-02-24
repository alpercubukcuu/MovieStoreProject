
using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.UpdateCategory;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistCategoryIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context);
            command.CategoryId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kategori bulunamadı...");

        }

        [Fact]
        public void WhenGivenCategoryIdinDB_Category_ShouldBeUpdate()
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context);

            UpdateCategoryModel model = new UpdateCategoryModel(){CategoryName="WhenGivenBookIdinDB_Book_ShouldBeUpdate"};            
            command.Model = model;
            command.CategoryId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var category =_context.Categories.SingleOrDefault(category=>category.Id == command.CategoryId);
            category.Should().NotBeNull();
            
        }
    }

}