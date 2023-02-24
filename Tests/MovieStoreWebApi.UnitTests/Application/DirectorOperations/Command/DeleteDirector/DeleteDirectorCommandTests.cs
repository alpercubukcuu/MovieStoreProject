


using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.DeleteDirector;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
       

        public DeleteDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenDirectorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yönetmen bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeCreated()
        {
            //arrange
           var director = new Director() {FirstName = "WhenValidInputsAreGiven_Director_ShouldBeCreated", LastName = "asdasdasdasd"};
           _context.Add(director);
           _context.SaveChanges();

           DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
           command.DirectorId = director.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            director = _context.Directors.SingleOrDefault(x=> x.Id == director.Id);
            director.Should().BeNull();

        }
    }

}