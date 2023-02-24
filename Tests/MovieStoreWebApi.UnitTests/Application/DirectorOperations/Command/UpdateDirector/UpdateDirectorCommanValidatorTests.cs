using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.UpdateDirector;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateDirectorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0,"Lor","Asd")]
        [InlineData(0,"Lo ","ASDF ")]
        [InlineData(1,"Lord"," SD")]
        [InlineData(0,"Lor","ASDF")]
        [InlineData(-1,"Lord Of", " ")]
        [InlineData(1," "," ")]
        [InlineData(1,"","ASDF")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int directorid, string firstname, string lastname)
        {
            //arrange
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.Model = new UpdateDirectorModel(){ FirstName=firstname, LastName=lastname};
            command.DirectorId=directorid;
            //act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"Lord Of The Rings","ASDF")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int directorid, string firstname, string lastname)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.Model = new UpdateDirectorModel()
            {
                FirstName = firstname,
                LastName = lastname                
            };
            command.DirectorId=directorid;

            UpdateDirectorCommandValidator validations=new UpdateDirectorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

      
    }

}