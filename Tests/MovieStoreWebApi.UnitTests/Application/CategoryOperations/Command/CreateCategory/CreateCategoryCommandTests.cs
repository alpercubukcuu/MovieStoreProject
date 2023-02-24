using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.CreateCategory;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.CategoryOperations.CreateCategory.CreateCategoryCommand;

namespace MovieStoreWebApi.Application.CategoryOperations.Command.CreateCategory
{
    public class CreateCategoryCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistCategoryIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var category = new Category() {CategoryName = "WhenAlreadyExistCategoryIsGiven_InvalidOperationException_ShouldBeReturn" };
            _context.Categories.Add(category);
            _context.SaveChanges();

            CreateCategoryCommand command = new CreateCategoryCommand(_context, _mapper);
            command.Model = new CreateCategoryModel() {CategoryName = category.CategoryName};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kategori zaten mevcut ...");

        }



        
       [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeCreated()
        {
            //arrange
            CreateCategoryCommand command = new CreateCategoryCommand(_context,_mapper);
            CreateCategoryModel model = new CreateCategoryModel() {CategoryName = "WhenValidInputsAreGiven_Category_ShouldBeCreated"};
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var category = _context.Categories.SingleOrDefault(category => category.CategoryName == model.CategoryName);
            category.Should().NotBeNull();
        }

        
    }
}