using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbcontext.Movies.SingleOrDefault(x=> x.Title == Model.Title);
            if(movie is not null)
                throw new InvalidOperationException("Film zaten mevcut ...");
            
            movie = _mapper.Map<Movie>(Model);
            
            _dbcontext.Movies.Add(movie);
            _dbcontext.SaveChanges();
        }

        public class CreateMovieModel
        {
            public string ?Title { get; set; }
            public string ?Release_year { get; set; }
            public int ?CategoryId { get; set; }
            public int ?Price { get; set; }

        }
    }
}