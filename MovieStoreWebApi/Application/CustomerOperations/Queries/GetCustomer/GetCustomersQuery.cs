
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.CustomerOperations.Queries
{
    public class GetCustomersQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetCustomersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public List<CustomersViewModel> Handle()
        {
            var customerlist = _context.Customers.Include(i=> i.CustomerCategories).ThenInclude(t=> t.Category).OrderBy(x => x.Id).ToList<Customer>();
            List<CustomersViewModel> vm = _mapper.Map<List<CustomersViewModel>>(customerlist);
            return vm;
        }

    }
    public class CustomersViewModel
    {
        public int Id { get; set; }
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public IReadOnlyList<string> Category { get; set; }
        public string ?Email { get; set; }
        public string ?Password {get; set;}


    }

}