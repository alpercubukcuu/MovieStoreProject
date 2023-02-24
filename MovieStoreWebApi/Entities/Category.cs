using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string ?CategoryName {get; set;}
        public bool IsActive {get; set;} = true;
        public virtual ICollection<MovieActor> ?MovieActors {get; set;}
        public virtual ICollection<CustomerCategory> ?CustomerCategories {get; set;}
       
    }
}