using FluentAssertions;
using MovieStoreWebApi.ActorOperations.UpdateActor;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.ActorOperations.UpdateActor.UpdateActorCommand;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateActorCommandValidatorTest(CommonTestFixture testFixture)
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
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int actorid, string firstname, string lastname)
        {
            //arrange
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Model = new UpdateActorModel(){ FirstName=firstname, LastName=lastname};
            command.ActorId=actorid;
            //act
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"Lord Of The Rings","ASDF")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int actorid, string firstname, string lastname)
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Model = new UpdateActorModel()
            {
                FirstName = firstname,
                LastName = lastname                
            };
            command.ActorId=actorid;

            UpdateActorCommandValidator validations=new UpdateActorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

      
    }

}