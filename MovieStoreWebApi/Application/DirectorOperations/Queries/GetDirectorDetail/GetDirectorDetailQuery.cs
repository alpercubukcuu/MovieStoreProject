using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.DirectorOperations.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int DirectorId {get; set;}

        public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DirectorDetailViewModel Handle()
        {
            var director = _context.Directors.Where(user=> user.Id == DirectorId).SingleOrDefault(); 
            if(director is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı...");  
            DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);
            return vm;      
        }
    }
     public class DirectorDetailViewModel
        {
            public int Id {get; set;}
            public string ?FirstName{ get; set; }
            public string ?LastName { get; set; }
           
        }
}

