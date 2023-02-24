using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.CategoryOperations.GetCategoryDetail
{
    public class GetCategoryDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CategoryId {get; set;}

        public GetCategoryDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoryDetailViewModel Handle()
        {
            var category = _context.Categories.Where(user=> user.Id == CategoryId).SingleOrDefault(); 
            if(category is null)
                throw new InvalidOperationException("Kategori bulunamadı...");  
            CategoryDetailViewModel vm = _mapper.Map<CategoryDetailViewModel>(category);
            return vm;      
        }
    }
     public class CategoryDetailViewModel
        {
            public int Id {get; set;}
            public string ?CategoryName{ get; set; }
           
           
        }
}

