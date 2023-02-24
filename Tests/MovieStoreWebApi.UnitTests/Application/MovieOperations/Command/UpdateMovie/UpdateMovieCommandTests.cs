
using FluentAssertions;
using MovieStoreWebApi.MovieOperations.UpdateMovie;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek film bulunamadı...");

        }

        [Fact]
        public void WhenGivenMovieIdinDB_Movie_ShouldBeUpdate()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);

            UpdateMovieModel model = new UpdateMovieModel(){Title = "WhenAlreadyExistMovieIsGiven", Release_year = "2006", CategoryId=1, Price = 100};            
            command.Model = model;
            command.MovieId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var movie =_context.Movies.SingleOrDefault(movie=>movie.Id == command.MovieId);
            movie.Should().NotBeNull();
            
        }
    }

}