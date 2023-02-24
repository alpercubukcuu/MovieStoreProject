using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange
            (
                new Movie { Title="Hızlı ve Öfkeli",                Release_year="2001", CategoryId = 1, Price = 100 },
                new Movie { Title="John Wick 2",                    Release_year="2017", CategoryId = 2, Price = 150 },
                new Movie { Title="Harry Potter ve Melez Prens",    Release_year="2009", CategoryId = 3, Price = 100 }
                   
             );

        }
    }
}