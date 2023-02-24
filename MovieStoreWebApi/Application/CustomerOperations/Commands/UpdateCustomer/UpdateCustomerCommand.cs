
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        
        public int CustomerId{get; set;}

        public UpdateCustomerModel Model{get; set;}
        
        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

      public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x=> x.Id == CustomerId);
            if(customer is null)
                throw new InvalidOperationException("Güncellenecek müşteri bulunamadı...");
            
            customer.FirstName = Model.FirstName != default ? Model.FirstName : customer.FirstName;
            customer.LastName = Model.LastName != default ? Model.LastName : customer.LastName;
            customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.Password != default ? Model.Password : customer.Password;
            

            _context.SaveChanges();
        }
    }
     public class UpdateCustomerModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
            public string ?Email { get; set; }
            public string ?Password { get; set; }
        }
}