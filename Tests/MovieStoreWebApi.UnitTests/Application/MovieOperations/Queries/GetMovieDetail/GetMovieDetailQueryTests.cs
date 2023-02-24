using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.MovieOperations.GetMovieDetail;
using MovieStoreWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace MovieStoreWebApi.Application.MovieOperations.Queries
{
    public class GetMovieDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenMovieIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetMovieDetailQuery command = new GetMovieDetailQuery(_context,_mapper);
            command.MovieId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Film bulunamadı...");
        }

        [Fact]
        public void WhenGivenMovieIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetMovieDetailQuery command = new GetMovieDetailQuery(_context,_mapper);
            command.MovieId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var movie=_context.Movies.SingleOrDefault(movie=>movie.Id == command.MovieId);
            movie.Should().NotBeNull();
        }
    }
}