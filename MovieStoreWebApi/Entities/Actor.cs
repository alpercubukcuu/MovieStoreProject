using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Actor
    {
        //Bir filmde birden fazla oyuncu oynayabilir, bir oyuncunun da birden fazla filmi olabilir.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string ?FirstName {get; set;}
        public string ?LastName {get; set;}
        public bool IsActive {get; set;} = true;
        public virtual ICollection<MovieActor> ?MovieActors {get; set;}
       
    }
}