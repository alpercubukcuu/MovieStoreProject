using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.MovieOperations.CreateMovie;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using TestSetup;
using Xunit;
using static MovieStoreWebApi.MovieOperations.CreateMovie.CreateMovieCommand;

namespace MovieStoreWebApi.Application.MovieOperations.Command.CreateMovie
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var movie = new Movie() {Title = "WhenAlreadyExistMovieIsGiven", Release_year = "2006", CategoryId=1, Price = 100};
            _context.Movies.Add(movie);
            _context.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = new CreateMovieModel() {Title = movie.Title, Release_year = movie.Release_year, CategoryId = movie.CategoryId, Price = movie.Price};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film zaten mevcut ...");

        }



        
        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            CreateMovieModel model = new CreateMovieModel() {Title = "WhenAlreadyExistMovieIsGiven", Release_year = "2006", CategoryId=1, Price = 100};
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var movie = _context.Movies.SingleOrDefault(movie => movie.Title == model.Title);
            movie.Should().NotBeNull();
            
        }
        
    }
}