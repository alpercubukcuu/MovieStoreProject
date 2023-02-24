
using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.ActorOperations.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        
        public int ActorId{get; set;}

        public UpdateActorModel Model{get; set;}
        
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

      public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x=> x.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Güncellenecek aktör bulunamadı...");
            
            actor.FirstName = Model.FirstName != default ? Model.FirstName : actor.FirstName;
            actor.LastName = Model.LastName != default ? Model.LastName : actor.LastName;
           

            _context.SaveChanges();
        }
         public class UpdateActorModel
        {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        }
    }
}