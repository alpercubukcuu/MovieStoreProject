
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.OrderOperations.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId {get; set;}
        public int CustomerId {get; set;}
        public int MovieId {get; set;}


        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
       
       
        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

      
        public void Handle()
        {

            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == Model.MovieId);
            var order = _dbContext.Orders.SingleOrDefault(x=> x.Id == OrderId);

            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            else if (order is null)
                throw new InvalidOperationException("Sipariş bulunamadı ...");
            
            order.MovieId = Model.MovieId != default ? Model.MovieId : order.MovieId;
            order.CustomerId = Model.CustomerId != default ? Model.CustomerId : order.CustomerId;
           

            _dbContext.SaveChanges();
        }
        
    }
     public class UpdateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }
        }
}