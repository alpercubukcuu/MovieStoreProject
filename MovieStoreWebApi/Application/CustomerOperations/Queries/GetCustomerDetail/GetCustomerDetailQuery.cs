using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.CustomerOperations.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId {get; set;}

        public GetCustomerDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDetailViewModel Handle()
        {
            var customer = _context.Customers.Include(i=> i.CustomerCategories).ThenInclude(t=> t.Category).Where(customer=> customer.Id == CustomerId).OrderBy(x => x.Id).SingleOrDefault(); 
            if(customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı...");  
            CustomerDetailViewModel vm = _mapper.Map<CustomerDetailViewModel>(customer);
            return vm;      
        }
    }
     public class CustomerDetailViewModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
            public string ?Email { get; set; }
            public string ?Password { get; set; }
            public IReadOnlyList<string> Category { get; set; }
        }
}

