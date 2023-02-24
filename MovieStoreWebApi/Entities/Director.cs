using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string ?FirstName {get; set;}
        public string ?LastName {get; set;}
        public bool IsActive {get; set;} = true;
        public virtual ICollection<MovieDirector> ?MovieDirectors {get; set;}
       
    }
}