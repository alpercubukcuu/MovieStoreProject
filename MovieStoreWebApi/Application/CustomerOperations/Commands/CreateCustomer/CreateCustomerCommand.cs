using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.CustomerOperations.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _dbcontext.Customers.SingleOrDefault(x=> x.Email == Model.Email);
            if(customer is not null)
                throw new InvalidOperationException("Müşteri zaten mevcut ...");
            
            customer = _mapper.Map<Customer>(Model);
            
            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
        }

        public class CreateCustomerModel
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
            public string ?Email { get; set; }
            public string ?Password { get; set; }
            public string ?RefreshToken { get; set; }
            public DateTime RefreshTokenExpireDate { get; set; }
        }
    }
}