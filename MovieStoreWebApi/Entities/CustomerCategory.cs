using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
   public class CustomerCategory
   {
        [ForeignKey("Customer")]
        public int CustomerId {get; set;}
        [ForeignKey("Category")]
        public int CategoryId {get; set;}
        public virtual Customer ?Customer {get; set;}
        public virtual Category ?Category { get; set; }
   } 
}

