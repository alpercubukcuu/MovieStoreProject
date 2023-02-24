using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.ActorOperations.CreateActor;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.ActorOperations.CreateActor.CreateActorCommand;

namespace MovieStoreWebApi.Application.ActorOperations.Command.CreateActor
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var actor = new Actor() {FirstName = "Ahmet", LastName="Adıvar"};
            _context.Actors.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorModel() {FirstName = actor.FirstName, LastName = actor.LastName};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aktör zaten mevcut ...");

        }



        
        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
            CreateActorCommand command = new CreateActorCommand(_context,_mapper);
            CreateActorModel model = new CreateActorModel() {FirstName="Ahmet", LastName="Adıvar" };
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var actor = _context.Actors.SingleOrDefault(actor => actor.FirstName == model.FirstName && actor.LastName == model.LastName);
            actor.Should().NotBeNull();
            
        }
        
    }
}