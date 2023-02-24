


using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.MovieOperations.DeleteMovie;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
       

        public DeleteMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenMovieIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek film bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            //arrange
            var movie = new Movie() {Title = "WhenAlreadyExistMovieIsGiven", Release_year = "2006", CategoryId=1, Price = 100};
            _context.Add(movie);
            _context.SaveChanges();

            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = movie.Id;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
           
            //assert
            movie = _context.Movies.Where(x=>x.IsActive).SingleOrDefault(x=> x.Id == movie.Id);
            movie.Should().BeNull();

        }
    }

}