using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.ActorOperations.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId {get; set;}
        
        private readonly IMovieStoreDbContext _context;

        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x=> x.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Silinecek aktör bulunamadı ...");
            
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }


}
