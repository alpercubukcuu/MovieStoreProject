using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId {get; set;}
        
        private readonly IMovieStoreDbContext _context;

        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x=> x.Id == MovieId);
            if(movie is null)
                throw new InvalidOperationException("Silinecek film bulunamadı ...");

            movie.IsActive = false;
            
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }


}
