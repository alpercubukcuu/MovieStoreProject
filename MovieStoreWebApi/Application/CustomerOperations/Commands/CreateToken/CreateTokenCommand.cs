using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Models;

namespace MovieStoreWebApi.CustomerOperations.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbcontext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

                _dbcontext.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Kullanıcı Adı - Şifre Hatalı!");
        }
    }

    public class CreateTokenModel
    {
        public string ?Email { get; set; }
        public string ?Password { get; set; }
    }
}