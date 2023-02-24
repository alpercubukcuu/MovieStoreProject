using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;


namespace MovieStoreWebApi.DBOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {}
        public DbSet<Actor> Actors {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Director> Directors {get; set;}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<MovieActor> MovieActors {get; set;}
        public DbSet<MovieDirector> MovieDirectors {get; set;}
        public DbSet<CustomerCategory> CustomerCategories {get; set;}

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<MovieActor>()
            .HasKey(x => new {x.MovieId, x.ActorId});

            modelBuilder.Entity<MovieDirector>()
            .HasKey(x => new {x.MovieId, x.DirectorId});

             modelBuilder.Entity<CustomerCategory>()
            .HasKey(x => new {x.CustomerId, x.CategoryId});
        }

        


    }
}