using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.OrderOperations.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _dbcontext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            var movies = _dbcontext.Movies.SingleOrDefault(s => s.Id == Model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
           

            var result = _mapper.Map<Order>(Model);
            result.purchasedTime = DateTime.Now;
            result.IsActive = true;

            _dbcontext.Orders.Add(result);
            _dbcontext.SaveChanges();
        }

        public class CreateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }
            DateTime purchasedTime = DateTime.Now;
            bool movieStatus = true;

        }
    }
}