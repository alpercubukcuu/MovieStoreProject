using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DBOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies {get; set;}
        DbSet<Actor> Actors {get; set;}
        DbSet<Category> Categories {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Director> Directors {get; set;}
        public DbSet<Order> Orders {get; set;}

        int SaveChanges();
       
    }
}