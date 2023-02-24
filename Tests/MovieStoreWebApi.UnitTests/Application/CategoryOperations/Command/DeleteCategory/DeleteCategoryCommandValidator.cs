
using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.DeleteCategory;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidCategoryIdIsGiven_Validator_ShouldBeReturnErrors(int categoryid)
        {
            //arrange
            DeleteCategoryCommand command = new DeleteCategoryCommand(null!);
            command.CategoryId = categoryid;
            
            //act
            DeleteCategoryCommandValidator validator = new DeleteCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int categoryid)
        {
            DeleteCategoryCommand command = new DeleteCategoryCommand(null!);
            command.CategoryId = categoryid;

            DeleteCategoryCommandValidator validator = new DeleteCategoryCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}