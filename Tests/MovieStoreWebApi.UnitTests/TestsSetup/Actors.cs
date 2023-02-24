using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
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
        }
    }
}