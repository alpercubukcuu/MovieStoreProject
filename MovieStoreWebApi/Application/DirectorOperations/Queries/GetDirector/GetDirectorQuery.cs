
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace DirectorStoreWebApi.Application.DirectorOperations.Queries
{
    public class GetDirectorQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public List<DirectorViewModel> Handle()
        {
            var directorlist = _context.Directors.OrderBy(x => x.Id).ToList<Director>();
            List<DirectorViewModel> vm = _mapper.Map<List<DirectorViewModel>>(directorlist);
            return vm;
        }

    }
    public class DirectorViewModel
    {
        public int Id { get; set; }
        public string ?FirstName{ get; set; }
        public string ?LastName { get; set; }
        
    }

}