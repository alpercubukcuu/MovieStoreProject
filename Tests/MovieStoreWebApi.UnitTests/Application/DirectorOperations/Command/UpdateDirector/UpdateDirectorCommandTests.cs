
using FluentAssertions;
using MovieStoreWebApi.DirectorOperations.UpdateDirector;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek aktör bulunamadı...");

        }

        [Fact]
        public void WhenGivenDirectorIdinDB_Director_ShouldBeUpdate()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);

            UpdateDirectorModel model = new UpdateDirectorModel(){FirstName="WhenGivenBookIdinDB_Book_ShouldBeUpdate", LastName="Rebart"};            
            command.Model = model;
            command.DirectorId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var director =_context.Directors.SingleOrDefault(director=>director.Id == command.DirectorId);
            director.Should().NotBeNull();
            
        }
    }

}