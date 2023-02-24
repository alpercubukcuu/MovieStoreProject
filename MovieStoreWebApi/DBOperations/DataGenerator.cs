using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {

                 context.Customers.AddRange(
                    new Customer { FirstName = "Aydın", LastName="Aktürk", Email="aydinaktürk@mail.com", Password="123456", RefreshToken=""},
                    new Customer { FirstName = "Melis", LastName="Ergin", Email="melisergin@mail.com", Password="654321", RefreshToken="" },
                    new Customer { FirstName = "Yunus", LastName="Emre", Email="yunusemre@mail.com", Password="124356", RefreshToken="" }

                );

             context.Movies.AddRange
                (
                    new Movie { Title="Hızlı ve Öfkeli",                Release_year="2001", CategoryId = 1, Price = 100 },
                    new Movie { Title="John Wick 2",                    Release_year="2017", CategoryId = 2, Price = 150 },
                    new Movie { Title="Harry Potter ve Melez Prens",    Release_year="2009", CategoryId = 3, Price = 100 }
                );

               context.Actors.AddRange(
                    new Actor { FirstName = "Vin",      LastName="Diesel",},
                    new Actor { FirstName = "Paul",     LastName="Walker",},
                    new Actor { FirstName = "Michelle", LastName="Rodriguez", },
                    new Actor { FirstName = "Keanu",    LastName="Reeves", },
                    new Actor { FirstName = "Ruby",     LastName="Rose", },
                    new Actor { FirstName = "Laurence", LastName="Fishburne", },
                    new Actor { FirstName = "Daniel",   LastName="Radcliffe", },
                    new Actor { FirstName = "Emma",     LastName="Watson", },
                    new Actor { FirstName = "Rupert",   LastName="Grint", }
                );

                  context.Directors.AddRange
                (
                    new Director { FirstName="Rob", LastName="Cohen" },
                    new Director { FirstName="Chad", LastName="Stahelski"},
                    new Director { FirstName="David", LastName="Yates"}
                   
                );

                 context.Categories.AddRange(
                    new Category { CategoryName = "Suç/Gerilim"},
                    new Category { CategoryName = "Aksiyon"},
                    new Category { CategoryName = "Macera"}

                );

                context.MovieActors.AddRange(
                    new MovieActor{ ActorId = 1, MovieId = 1},
                    new MovieActor{ ActorId = 2, MovieId = 1},
                    new MovieActor{ ActorId = 3, MovieId = 1},
                    new MovieActor{ ActorId = 4, MovieId = 2},
                    new MovieActor{ ActorId = 5, MovieId = 2},
                    new MovieActor{ ActorId = 6, MovieId = 2},
                    new MovieActor{ ActorId = 7, MovieId = 3},
                    new MovieActor{ ActorId = 8, MovieId = 3},
                    new MovieActor{ ActorId = 9, MovieId = 3}
                    );
                    
                 context.MovieDirectors.AddRange(
                    new MovieDirector{ MovieId = 1, DirectorId = 1},
                    new MovieDirector{ MovieId = 2, DirectorId = 2},
                    new MovieDirector{ MovieId = 3, DirectorId = 3}
                    );

                 context.Orders.AddRange(
                  new Order { CustomerId = 1 , MovieId = 1, purchasedTime = new DateTime(2022, 07, 06) , IsActive = true },
                  new Order { CustomerId = 2 , MovieId = 1, purchasedTime = new DateTime(2022, 12, 05) , IsActive = true },
                  new Order { CustomerId = 3 , MovieId = 2, purchasedTime = new DateTime(2022, 08, 25) , IsActive = true }
                  );

                context.CustomerCategories.AddRange(
                    new CustomerCategory{ CustomerId = 1, CategoryId = 1},
                    new CustomerCategory{ CustomerId = 1, CategoryId = 2},
                    new CustomerCategory{ CustomerId = 1, CategoryId = 3},
                    new CustomerCategory{ CustomerId = 2, CategoryId = 2},
                    new CustomerCategory{ CustomerId = 2, CategoryId = 3},
                    new CustomerCategory{ CustomerId = 3, CategoryId = 1}
                    );


         
                


                context.SaveChanges();
            }
        }
    }
}