using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.CategoryOperations.DeleteCategory
{
    public class DeleteCategoryCommand
    {
        public int CategoryId {get; set;}
        
        private readonly IMovieStoreDbContext _context;

        public DeleteCategoryCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var Category = _context.Categories.SingleOrDefault(x=> x.Id == CategoryId);
            if(Category is null)
                throw new InvalidOperationException("Silinecek kategori bulunamadı ...");
            
            _context.Categories.Remove(Category);
            _context.SaveChanges();
        }
    }


}
