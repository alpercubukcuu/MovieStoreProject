using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context {get; set;}
        public IMapper Mapper {get; set;}

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName:"MovieStoreTestDB").Options;
            Context = new MovieStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddActors();
            Context.AddCategories();
            Context.AddCustomerCategories();
            Context.AddCustomers();
            Context.AddDirectors();
            Context.AddMovieActors();
            Context.AddMovieDirectors();
            Context.AddMovies();
            Context.AddOrders();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
            
        }
    }
}