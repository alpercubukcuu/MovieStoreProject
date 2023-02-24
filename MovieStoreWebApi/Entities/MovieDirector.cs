using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
   public class MovieDirector
   {
        [ForeignKey("Movie")]
        public int MovieId {get; set;}
        [ForeignKey("Director")]
        public int DirectorId {get; set;}
        public virtual Movie ?Movie {get; set;}
        public virtual Director ?Director { get; set; }
   } 
}
