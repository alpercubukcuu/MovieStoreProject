using FluentAssertions;
using MovieStoreWebApi.CategoryOperations.UpdateCategory;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.CategoryOperations.Commands.Category
{
    public class CategoryCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public CategoryCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData("Lor")]
        [InlineData("Lo ")]
        [InlineData("Lord")]
        [InlineData("Lor")]
        [InlineData(" a")]
        [InlineData(" ")]
        [InlineData("a")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string categoryname)
        {
            //arrange
            UpdateCategoryCommand command = new UpdateCategoryCommand(null);
            command.Model = new UpdateCategoryModel(){ CategoryName=categoryname};
            //act
            UpdateCategoryCommandValidator validator = new UpdateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"Lord Of The Rings")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int categoryid, string categoryname)
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(null);
            command.Model = new UpdateCategoryModel()
            {
                CategoryName = categoryname            
            };
            command.CategoryId=categoryid;

            UpdateCategoryCommandValidator validations=new UpdateCategoryCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

      
    }

}