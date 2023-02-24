
using FluentAssertions;
using MovieStoreWebApi.ActorOperations.UpdateActor;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.ActorOperations.UpdateActor.UpdateActorCommand;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek aktör bulunamadı...");

        }

        [Fact]
        public void WhenGivenActorIdinDB_Actor_ShouldBeUpdate()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);

            UpdateActorModel model = new UpdateActorModel(){FirstName="WhenGivenBookIdinDB_Book_ShouldBeUpdate", LastName="Rebart"};            
            command.Model = model;
            command.ActorId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var actor =_context.Actors.SingleOrDefault(actor=>actor.Id == command.ActorId);
            actor.Should().NotBeNull();
            
        }
    }

}