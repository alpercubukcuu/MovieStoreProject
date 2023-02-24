
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.MovieOperations.Queries
{
    public class GetMovieQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public List<MovieViewModel> Handle()
        {
            var movielist = _context.Movies.Include(x=> x.Category).Include(i=> i.MovieActors).ThenInclude(t=> t.Actor).Include(i => i.MovieDirectors).ThenInclude(t=> t.Director).Where(a => a.IsActive).ToList<Movie>();
            List<MovieViewModel> vm = _mapper.Map<List<MovieViewModel>>(movielist);
            return vm;
        }

    }
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string ?Title{ get; set; }
        public string ?Release_year { get; set; }
        public string ?Category{ get; set; }
        public IReadOnlyCollection<string> Director { get; set; }
        public IReadOnlyList<string> Actors { get; set; }
        public int Price {get; set;}


    }

}