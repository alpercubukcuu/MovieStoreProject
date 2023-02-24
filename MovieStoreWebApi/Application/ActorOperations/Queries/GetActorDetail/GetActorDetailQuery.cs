using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.ActorOperations.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int ActorId {get; set;}

        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
            var actor = _context.Actors.Where(actor=> actor.Id == ActorId).SingleOrDefault(); 
            if(actor is null)
                throw new InvalidOperationException("Aktör bulunamadı...");  
            ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);
            return vm;      
        }
    }
     public class ActorDetailViewModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
           
        }
}

