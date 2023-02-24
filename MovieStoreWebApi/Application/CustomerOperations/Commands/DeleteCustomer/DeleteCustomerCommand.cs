using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId {get; set;}
        
        private readonly IMovieStoreDbContext _context;

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x=> x.Id == CustomerId);
            if(customer is null)
                throw new InvalidOperationException("Silinecek müşteri bulunamadı ...");
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }


}
