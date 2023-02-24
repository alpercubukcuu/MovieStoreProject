using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DirectorOperations.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbcontext.Directors.SingleOrDefault(x=> x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if(director is not null)
                throw new InvalidOperationException("Yönetmen zaten mevcut ...");
            
            director = _mapper.Map<Director>(Model);
            
            _dbcontext.Directors.Add(director);
            _dbcontext.SaveChanges();
        }

        public class CreateDirectorModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }

        }
    }
}