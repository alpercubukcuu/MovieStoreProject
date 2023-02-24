
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.OrderOperations.Queries
{
    public class GetOrderQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public List<OrderViewModel> Handle()
        {
            var orderlist = _context.Customers.Include(i => i.Order).ThenInclude(t => t.Movie).Where(w => w.Order.Any(a => a.IsActive)).OrderBy(x => x.Id).ToList<Customer>();
            List<OrderViewModel> vm = _mapper.Map<List<OrderViewModel>>(orderlist);
            return vm;


        }

    }
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FirstNameLastname { get; set; }
        public IReadOnlyCollection<string> Movies { get; set; }
        public IReadOnlyCollection<string> Price { get; set; }
        public IReadOnlyCollection<string> PurchasedDate { get; set; }
    }

}