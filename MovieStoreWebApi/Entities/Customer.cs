using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Customer
    {

        //Müşterinin birden fazla favori film türü olabilir. Satın aldığı bir türü tekrar satın alabilir.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int MovieId {get; set;}
        public Movie ?Movie {get; set;}
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public bool IsActive {get; set;} = true;
        public virtual ICollection<Order> ?Order { get; set; }
        public virtual ICollection<MovieActor> ?MovieActors {get; set;}
        public virtual ICollection<CustomerCategory> ?CustomerCategories {get; set;}

    }
}