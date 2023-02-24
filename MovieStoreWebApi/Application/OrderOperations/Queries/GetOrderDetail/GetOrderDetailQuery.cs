using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.OrderOperations.GetOrderDetail
{
    public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId {get; set;}

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public OrderDetailViewModel Handle()
        {
            var order = _context.Orders.SingleOrDefault(s => s.Id == OrderId);
                if(order is null)
                    throw new InvalidOperationException("Sipariş bulunamadı ...");
            
            var customer = _context.Customers.Include(i => i.Order).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == OrderId); 
            OrderDetailViewModel vm = _mapper.Map<OrderDetailViewModel>(customer);

            return vm;      
        }
    }
     public class OrderDetailViewModel
        {
            public string FirstNameLastname { get; set; }
            public IReadOnlyCollection<string> Movies { get; set; }
            public IReadOnlyCollection<string> Price { get; set; }
            public IReadOnlyCollection<string> PurchasedDate { get; set; }
           
        }
}

