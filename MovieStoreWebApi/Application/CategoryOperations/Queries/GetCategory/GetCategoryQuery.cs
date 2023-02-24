
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace CategoryStoreWebApi.Application.CategoryOperations.Queries
{
    public class GetCategoryQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetCategoryQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public List<CategoryViewModel> Handle()
        {
            var categorylist = _context.Categories.OrderBy(x => x.Id).ToList<Category>();
            List<CategoryViewModel> vm = _mapper.Map<List<CategoryViewModel>>(categorylist);
            return vm;
        }

    }
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string ?CategoryName{ get; set; }
        
    }

}