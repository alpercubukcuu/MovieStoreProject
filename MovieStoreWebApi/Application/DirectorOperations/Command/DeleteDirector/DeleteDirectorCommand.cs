using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId {get; set;}
        
        private readonly IMovieStoreDbContext _context;

        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var Director = _context.Directors.SingleOrDefault(x=> x.Id == DirectorId);
            if(Director is null)
                throw new InvalidOperationException("Silinecek yönetmen bulunamadı ...");
            
            _context.Directors.Remove(Director);
            _context.SaveChanges();
        }
    }


}
