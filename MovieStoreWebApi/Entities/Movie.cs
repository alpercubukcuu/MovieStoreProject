
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Movie
    {
        //Yönetmenler ve oyuncular ayrı tutulmalıdır. Bir oyuncu aynı zamanda yönetmen de olabilir, ama bunlar iki ayrı yapıdır.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string ?Title {get; set;} //Film Adı
        public string ?Release_year {get; set;} //Film Yılı
        public int CategoryId {get; set;} //Film Türü
        public Category? Category {get; set;}
        public int Price {get; set;} //Fiyat
        public bool IsActive {get; set;} = true;
        public virtual ICollection<MovieActor> ?MovieActors {get; set;}
        public virtual ICollection<MovieDirector> ?MovieDirectors {get; set;}

    }
}