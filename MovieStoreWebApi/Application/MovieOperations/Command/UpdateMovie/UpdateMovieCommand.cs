
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        
        public int MovieId{get; set;}

        public UpdateMovieModel Model{get; set;}
        
        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

      public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x=> x.Id == MovieId);
            if(movie is null)
                throw new InvalidOperationException("Güncellenecek film bulunamadı...");
            
            movie.Title = Model.Title != default ? Model.Title : movie.Title;
            movie.Release_year = Model.Release_year != default ? Model.Release_year : movie.Release_year;
            movie.CategoryId = Model.CategoryId != default ? Model.CategoryId : movie.CategoryId;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            

            _context.SaveChanges();
        }
    }
     public class UpdateMovieModel
        {
            public string ?Title { get; set; }
            public string ?Release_year { get; set; }
            public int CategoryId { get; set; }
            public int Price { get; set; }
        }
}