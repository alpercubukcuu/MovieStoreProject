
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.ActorOperations.Queries
{
    public class GetActorQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetActorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public List<ActorViewModel> Handle()
        {
            var actorlist = _context.Actors.Include(i=> i.MovieActors).ThenInclude(t=> t.Movie).OrderBy(x => x.Id).ToList<Actor>();
            List<ActorViewModel> vm = _mapper.Map<List<ActorViewModel>>(actorlist);
            return vm;
        }

    }
    public class ActorViewModel
    {
        public int Id {get; set;} 
        public string ?FirstName{ get; set; } 
        public string ?LastName { get; set; }
        public IReadOnlyList<string> Movies { get; set; }

        
    }

}