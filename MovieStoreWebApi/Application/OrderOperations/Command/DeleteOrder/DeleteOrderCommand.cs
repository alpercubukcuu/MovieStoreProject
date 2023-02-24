using MovieStoreWebApi.DBOperations;


namespace MovieStoreWebApi.OrderOperations.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId {get; set;}
        
        private readonly IMovieStoreDbContext _context;

        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x=> x.Id == OrderId);
            if(order is null)
                throw new InvalidOperationException("Silinecek sipariş bulunamadı ...");
            
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }


}
