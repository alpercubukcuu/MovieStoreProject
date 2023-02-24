using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.ActorOperations.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbcontext.Actors.SingleOrDefault(x=> x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if(actor is not null)
                throw new InvalidOperationException("Aktör zaten mevcut ...");
            
            actor = _mapper.Map<Actor>(Model);
            
            _dbcontext.Actors.Add(actor);
            _dbcontext.SaveChanges();
        }
        public class CreateActorModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }

        }
    }
}