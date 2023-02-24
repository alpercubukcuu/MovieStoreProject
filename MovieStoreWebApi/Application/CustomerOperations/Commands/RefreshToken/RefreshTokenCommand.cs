
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Models;


namespace MovieStoreWebApi.CustomerOperations.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbcontext.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Valid bir Refresh Token Bulunamadı!");
        }
    }
}