
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.CategoryOperations.UpdateCategory
{
    public class UpdateCategoryCommand
    {
        private readonly IMovieStoreDbContext _context;
        
        public int CategoryId{get; set;}

        public UpdateCategoryModel Model{get; set;}
        
        public UpdateCategoryCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

      public void Handle()
        {
            var category = _context.Categories.SingleOrDefault(x=> x.Id == CategoryId);
            if(category is null)
                throw new InvalidOperationException("Güncellenecek kategori bulunamadı...");
            
            category.CategoryName = Model.CategoryName != default ? Model.CategoryName : category.CategoryName;
          
           

            _context.SaveChanges();
        }
    }
     public class UpdateCategoryModel
        {
            public string ?CategoryName { get; set; }
        }
}