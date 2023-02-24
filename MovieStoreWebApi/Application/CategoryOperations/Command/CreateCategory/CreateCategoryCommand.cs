using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.CategoryOperations.CreateCategory
{
    public class CreateCategoryCommand
    {
        public CreateCategoryModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateCategoryCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var category = _dbcontext.Categories.SingleOrDefault(x=> x.CategoryName == Model.CategoryName);
            if(category is not null)
                throw new InvalidOperationException("Kategori zaten mevcut ...");
            
            category = _mapper.Map<Category>(Model);
            
            _dbcontext.Categories.Add(category);
            _dbcontext.SaveChanges();
        }

        public class CreateCategoryModel
        {
            public string ?CategoryName { get; set; }

        }
    }
}