
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        
        public int DirectorId{get; set;}

        public UpdateDirectorModel Model{get; set;}
        
        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

      public void Handle()
        {
            var Director = _context.Directors.SingleOrDefault(x=> x.Id == DirectorId);
            if(Director is null)
                throw new InvalidOperationException("Güncellenecek aktör bulunamadı...");
            
            Director.FirstName = Model.FirstName != default ? Model.FirstName : Director.FirstName;
            Director.LastName = Model.LastName != default ? Model.LastName : Director.LastName;
           

            _context.SaveChanges();
        }
    }
     public class UpdateDirectorModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
        }
}