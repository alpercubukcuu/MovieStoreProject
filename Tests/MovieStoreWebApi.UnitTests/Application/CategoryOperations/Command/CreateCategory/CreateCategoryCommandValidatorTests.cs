using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.CreateCategory;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.CategoryOperations.CreateCategory.CreateCategoryCommand;

namespace MovieStoreWebApi.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(" ")]
        [InlineData(" ")]
        [InlineData("asd")]
        [InlineData("as")]
        [InlineData("a")]
        [InlineData("aaa")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string categoryname)
        {
            //arrange
            CreateCategoryCommand command = new CreateCategoryCommand(null, null);
            command.Model = new CreateCategoryModel(){CategoryName = categoryname};
            
            //act
            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf ")]
        [InlineData("asdf")]
        [InlineData("as  ")]
        [InlineData(" as ")]
        [InlineData("asdadasdasd")]
        [InlineData(" aaa")]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string categoryname)
        {
            //arrange
            CreateCategoryCommand command = new CreateCategoryCommand(null, null);
            command.Model = new CreateCategoryModel(){CategoryName = categoryname};
            
            //act
            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}