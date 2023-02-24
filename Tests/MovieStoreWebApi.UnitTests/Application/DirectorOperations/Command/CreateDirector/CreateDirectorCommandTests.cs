using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.CreateDirector;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.DirectorOperations.CreateDirector.CreateDirectorCommand;

namespace MovieStoreWebApi.Application.DirectorOperations.Command.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var director = new Director() {FirstName = "Ahmet", LastName="Adıvar"};
            _context.Directors.Add(director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = new CreateDirectorModel() {FirstName = director.FirstName, LastName = director.LastName};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen zaten mevcut ...");

        }



        
        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeCreated()
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(_context,_mapper);
            CreateDirectorModel model = new CreateDirectorModel() {FirstName="Ahmet", LastName="Adıvar" };
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var director = _context.Directors.SingleOrDefault(director => director.FirstName == model.FirstName && director.LastName == model.LastName);
            director.Should().NotBeNull();
            
        }
        
    }
}