using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
   public class MovieActor
   {
        [ForeignKey("Movie")]
        public int MovieId {get; set;}
        [ForeignKey("Actor")]
        public int ActorId {get; set;}
        public virtual Movie ?Movie {get; set;}
        public virtual Actor ?Actor { get; set; }
   } 
}

