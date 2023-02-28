using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Models;
using MovieStoreWebApi.Chiper;

namespace MovieStoreWebApi.CustomerOperations.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model {get; set;}
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
            _dataProtectionProvider = dataProtectionProvider;
        }

        public Token Handle()
        {
            var customer = _dbcontext.Customers.FirstOrDefault(x => x.Email == Model.Email);
            Chipers chiper = new(_dataProtectionProvider ,customer.Email);
           
            var decPassword = chiper.Decrypt(customer.Password);

            if (Model.Password == decPassword)
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