


using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.ActorOperations.DeleteActor;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
       

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenActorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek aktör bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
           var actor = new Actor() {FirstName = "WhenValidInputsAreGiven_Actor_ShouldBeCreated", LastName = "asdasdasdasd"};
           _context.Add(actor);
           _context.SaveChanges();

           DeleteActorCommand command = new DeleteActorCommand(_context);
           command.ActorId = actor.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            actor = _context.Actors.SingleOrDefault(x=> x.Id == actor.Id);
            actor.Should().BeNull();

        }
    }

}