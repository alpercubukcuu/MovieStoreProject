using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int MovieId {get; set;}

        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _context.Movies.Include(x=> x.Category).Include(i=> i.MovieActors).ThenInclude(t=> t.Actor).Include(i => i.MovieDirectors).ThenInclude(t=> t.Director).Where(user=> user.Id == MovieId).Where(a=> a.IsActive).SingleOrDefault(); 
            if(movie is null)
                throw new InvalidOperationException("Film bulunamadı...");  
            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
            return vm;      
        }
    }
     public class MovieDetailViewModel
        {
            public string ?Title { get; set; }
            public string ?Release_year { get; set; }
            public string ?Category{ get; set; }
            public IReadOnlyCollection<string> Director { get; set; }
            public IReadOnlyList<string> Actors { get; set; }
            public int Price{ get; set; }
        }
}

